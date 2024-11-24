using System;
using System.Collections;
using UnityEngine;

public class Enemy : PoolableObject<Enemy>, IInteractable
{
    [SerializeField] private float _shotFrequency;

    private BulletPool _bulletPool;

    public event Action<Enemy> Died;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerBullet bullet))
        {
            _bulletPool.ReleaseObjects(bullet);
            Died?.Invoke(this);
        }
    }

    public void Init(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
        StartCoroutine(FireWithInterval(new WaitForSeconds(_shotFrequency)));
    }

    private IEnumerator FireWithInterval(WaitForSeconds wait)
    {
        while (enabled)
        {
            Shoot();
            yield return wait;
        }
    }

    private void Shoot()
    {
        Bullet bullet = _bulletPool.GetObjects();
        bullet.transform.position = transform.position;
    }
}
