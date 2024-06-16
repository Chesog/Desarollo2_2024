using System;
using System.IO;
using UnityEngine;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";
    private bool useEncryption = false;
    private readonly string encryptionCodeWord = "jumpy";


    public FileDataHandler(string dataDirPath,string dataFileName,bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                // Load the serialized data from the file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                
                // optionally decrypt the data
                if (useEncryption) 
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }
                
                // deserialize the data from Json back to the c# object
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error ocurred when trying to Load data to file : " + fullPath + "\n" + e);
            }
        }


        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            
            // serialize the c# game data objet to Json
            string dataToStore = JsonUtility.ToJson(data, true);
            
            // optionally encrypt the data
            if (useEncryption) 
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }
            
            // write the serialized data to the file
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error ocurred when trying to save data to file : " + fullPath + "\n" + e);
        }
        
        
    }
    
    // simple implementation of XOR encryption
    private string EncryptDecrypt(string data) 
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++) 
        {
            modifiedData += (char) (data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }

}
