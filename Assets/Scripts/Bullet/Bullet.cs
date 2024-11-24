using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : PoolableObject<Bullet>, IInteractable
{
    [SerializeField] private float _speedX;

    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(_speedX, _rigidbody.velocity.y);
    }

    public void ChangeDirection(Vector2 direction)
    {
        _rigidbody.velocity = direction * _speedX;
        transform.up = direction;
    }
}
