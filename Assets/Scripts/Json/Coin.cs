using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour , ISaveableFile
{
    [SerializeField] private string coinId;
    private bool isColected;

    [ContextMenu("Generate Coin ID")]
    private void GenerateId()
    {
        coinId = Guid.NewGuid().ToString();
    }

    void Start()
    {
        if (!isColected)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }


    public void LoadData(GameData data)
    {
        data.coinsColected.TryGetValue(coinId, out isColected);
        
        if (isColected)
            gameObject.SetActive(false);
    }

    public void SaveData(ref GameData data)
    {
        if (data.coinsColected.ContainsKey(coinId))
            data.coinsColected[coinId] = isColected;
        else
            data.coinsColected.Add(coinId,isColected);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UiHandler.instance.AddCoin();
            isColected = true;
            gameObject.SetActive(false);
        }
    }
}
