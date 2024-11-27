using System;
using System.Collections;
using UnityEngine;

public class Enemy : PoolableObject<Enemy>, IInteractable
{
    [SerializeField] private float _shotFrequency;

    private BulletPool _bullets;

    private bool _isDie;

    public event Action<Enemy> Died;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerBullet _) && _isDie == false)
        {
            Debug.Log("Enemy die"); 
            _isDie = true;
            Died?.Invoke(this);
        }
    }

    public void Init(BulletPool bulletPool)
    {
        Debug.Log("Init Enemy");
        _isDie = false;
        _bullets = bulletPool;
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
        Bullet bullet = _bullets.GetObjects();
        bullet.transform.position = transform.position;
    }
}
