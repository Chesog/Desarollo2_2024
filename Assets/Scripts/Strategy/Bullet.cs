using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.collider.tag);
        
        if (other.collider.tag != "Player")
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
