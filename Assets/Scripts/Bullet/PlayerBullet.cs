using System;
using UnityEngine;

public class PlayerBullet : Bullet
{
    public event Action<PlayerBullet> Killed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            Killed?.Invoke(this);
        }
    }
}
