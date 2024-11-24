using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : PoolableObject<Bullet>, IInteractable
{
    [SerializeField] private float _speedX;

    private void OnEnable()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(_speedX, rigidbody.velocity.y);
    }
}
