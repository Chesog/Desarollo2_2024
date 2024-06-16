using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private List<BaseStrategy> shots;
    [SerializeField] private int currentWeaponIndex;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float speed;
    [SerializeField] private Transform bulletSpawn;
    private Vector2 movement;

    public void Update()
    {
        if(Input.GetButtonDown("Fire1"))
            Shoot(currentWeaponIndex);

        if (Input.GetButtonDown("Fire2"))
        {
            if (currentWeaponIndex >= shots.Count - 1)
                currentWeaponIndex = 0;
            else
                currentWeaponIndex++;
        }
        
        float x = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(x,0);
        
        _rb.AddForce(movement * speed);
    }

    public void Shoot(int index)
    {
        shots[index].BaseAction(bulletSpawn);
    }
}
