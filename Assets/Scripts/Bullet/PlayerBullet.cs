using System;
using UnityEngine;

public class PlayerBullet : Bullet
{
    public event Action<PlayerBullet> Killed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy _))
        {
            Killed?.Invoke(this);
        }
    }
}
