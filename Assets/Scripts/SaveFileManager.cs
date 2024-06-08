using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct Player
{
    public string name;
    public int id;
    public int level;
    public Vector2 position;
}

public class SaveFileManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEnciption;
    
    
    
    private GameData _gameData;
    private List<ISaveableFile> _saveableObjects;
    private FileDataHandler _dataHandler;
    public static SaveFileManager instance { get; private set; }

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one SaveFileManager in the scene");
            Destroy(this);
        }
        instance = this;
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void Start()
    {
        _dataHandler = new FileDataHandler(Application.dataPath,fileName,useEnciption);
        _saveableObjects = FindAllSaveableObjects();
        LoadGame();
    }
    public void NewGame()
    {
        _gameData = new GameData();
    }
    
    public void SaveGame()
    {
        foreach (ISaveableFile saveableFile in _saveableObjects)
        {
            saveableFile.SaveData(ref _gameData);
        }
        
        // Save data to a file using data handler
        _dataHandler.Save(_gameData);
    }
    
    public void LoadGame()
    {
        // Load any saved data from a file using data handler
        _gameData = _dataHandler.Load();
        
        // If no data can be loaded initialize a new game 
        if (_gameData == null)
        {
            Debug.Log("No save file found , Initializing a new save file with default values");
            NewGame();
        }

        foreach (ISaveableFile saveableFile in _saveableObjects)
        {
            saveableFile.LoadData(_gameData);
        }
    }
    
    private List<ISaveableFile> FindAllSaveableObjects()
    {
        IEnumerable<ISaveableFile> saveableObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISaveableFile>();
        return new List<ISaveableFile>(saveableObjects);
    }
}
