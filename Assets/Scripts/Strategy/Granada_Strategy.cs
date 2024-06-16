using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "Granada_Strategy",menuName = ("ScriptableObject/BulletStrategy/Granada"))]
public class Granada_Strategy : BaseStrategy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Rigidbody2D _rb;
    public override void BaseAction(Transform origin)
    {
        Vector2 direction = Vector2.right + Vector2.up;
        Instantiate(bulletPrefab,origin.position,quaternion.identity,origin);
        _rb.AddForce(direction,ForceMode2D.Impulse);
    }
}
