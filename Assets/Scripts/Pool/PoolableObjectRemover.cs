using UnityEngine;

public class PoolableObjectRemover<T> : MonoBehaviour where T : PoolableObject<T>
{
    [SerializeField] private Pool<T> _pool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out T poolableObject))
        {
            if (poolableObject.gameObject.activeSelf == false) // MVP
            {
                return;
            }

            _pool.ReleaseObjects(poolableObject);
        }
    }
}
