using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour , ISaveableFile
{
    [SerializeField] private Player _player;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float speed;
    private Vector2 movement;
    
    void Update()
    {
        float HorizontalMovement = Input.GetAxis("Horizontal");
        float VerticalMovement = Input.GetAxis("Vertical");

        movement = new Vector2(HorizontalMovement,VerticalMovement);
        
        _rb.AddForce(movement * speed);

        _player.position = transform.position;
    }

    public void LoadData(GameData data)
    {
        _player = data._Player;
        transform.position = data._Player.position;
    }

    public void SaveData(ref GameData data)
    {
        data._Player = _player;
    }

    public void AddLevel(int level)
    {
        _player.level = level;
    }
}
