using System;
using System.Collections;
using UnityEngine;

public class Enemy : PoolableObject<Enemy>, IInteractable
{
    [SerializeField] private float _shotFrequency;

    private BulletPool _bullets;

    public event Action<Enemy> Died;
    public event Action<Enemy> Released;

    public void Init(BulletPool bulletPool)
    {
        Debug.Log("Init Enemy");
        _bullets = bulletPool;
        StartCoroutine(FireWithInterval(new WaitForSeconds(_shotFrequency)));
    }

    public void Die()
    {
        Died?.Invoke(this);
    }

    public void Release()
    {
        Released?.Invoke(this);
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
        Bullet bullet = _bullets.GetObjects();
        bullet.transform.position = transform.position;
    }
}
