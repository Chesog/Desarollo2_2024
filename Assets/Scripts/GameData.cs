using UnityEngine;

[System.Serializable]
public class GameData
{
    public Player _Player;
    public SerializableDictionary<string, bool> coinsColected;
    public GameData()
    {
        _Player.level = 0;
        _Player.id = 0;
        _Player.name = "";
        _Player.position = Vector2.zero;

        coinsColected = new SerializableDictionary<string,bool>();
    }
}
