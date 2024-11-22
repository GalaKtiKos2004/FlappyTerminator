using UnityEngine;

public class PipeRemover : MonoBehaviour
{
    [SerializeField] private EnemysPool _pool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            if (enemy.gameObject.activeSelf == false) // MVP
            {
                return;
            }

            _pool.ReleaseObjects(enemy);
        }
    }
}
