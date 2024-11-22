using System.Collections;
using UnityEngine;

public class Enemy : PoolableObject<Enemy>, IInteractable
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private float _shotFrequency;

    private void Awake()
    {
        StartCoroutine(FireWithInterval(new WaitForSeconds(_shotFrequency)));
    }

    private IEnumerator FireWithInterval(WaitForSeconds wait)
    {
        while (enabled)
        {
            Shot();
            yield return wait;
        }
    }

    private void Shot()
    {
        Bullet bullet = _bulletPool.GetObjects();
        bullet.transform.position = transform.position;
    }
}
