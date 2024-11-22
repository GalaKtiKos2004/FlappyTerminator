using System.Collections.Generic;
using UnityEngine.Pool;

public class BulletPool : Pool<Bullet>
{
    private List<Bullet> _createdBullet;

    private ObjectPool<Bullet> _bullets;

    private void Awake()
    {
        
    }
}
