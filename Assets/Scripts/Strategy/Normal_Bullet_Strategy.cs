
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "Normal_Bullet_Strategy",menuName = ("ScriptableObject/BulletStrategy/NormalBullet"))]
public class Normal_Bullet_Strategy : BaseStrategy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Rigidbody2D _rb;

    public override void BaseAction(Transform origin)
    {
        Instantiate(bulletPrefab,origin.position,quaternion.identity,origin);
     
        _rb.AddForce(origin.right ,ForceMode2D.Impulse);
    }
}
