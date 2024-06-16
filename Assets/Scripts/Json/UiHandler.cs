using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiHandler : MonoBehaviour,ISaveableFile
{
    public TextMeshProUGUI levelUpText;
    public TextMeshProUGUI coinsText;
    [SerializeField] private PlayerController player;
    private int level;
    private int colectedCoins;
    
    public static UiHandler instance { get; private set; }

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one SaveFileManager in the scene");
            Destroy(this);
        }
        instance = this;
    }
    
    void Update()
    {
        levelUpText.text = "Player Level : " + level;
        coinsText.text = "Player coins : " + colectedCoins;
    }

    public void LevelUp()
    {
        level ++;
        player.AddLevel(level);
    }

    public void AddCoin()
    {
        colectedCoins++;
    }

    public void LoadData(GameData data)
    {
        level = data._Player.level;
        
        foreach (KeyValuePair<string,bool> pair in data.coinsColected)
        {
            if (pair.Value)
                colectedCoins++;
        }
    }

    public void SaveData(ref GameData data)
    {
        data._Player.level = level;
    }
}
