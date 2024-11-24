using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class BirdShooter : MonoBehaviour
{
    [SerializeField] BulletPool _bulletPool;

    private PlayerInput _input;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _input.Shooting += Shoot;
    }

    private void OnDisable()
    {
        _input.Shooting -= Shoot;
    }

    private void Shoot()
    {
        Bullet bullet = _bulletPool.GetObjects();
        bullet.transform.position = transform.position;

        bullet.ChangeDirection(transform.right);
    }
}
