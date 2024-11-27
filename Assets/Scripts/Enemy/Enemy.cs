using System;
using System.Collections;
using UnityEngine;

public class Enemy : PoolableObject<Enemy>, IInteractable
{
    [SerializeField] private float _shotFrequency;

    private BulletPool _bullets;

    private bool _isDie;

    public event Action<Enemy> Died;

    public void Init(BulletPool bulletPool)
    {
        Debug.Log("Init Enemy");
        _isDie = false;
        _bullets = bulletPool;
        StartCoroutine(FireWithInterval(new WaitForSeconds(_shotFrequency)));
    }

    public void Die()
    {
        Died?.Invoke(this);
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
