using UnityEngine;

public class PipeRemover : MonoBehaviour
{
    [SerializeField] private PipesPool _pool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Pipe pipe))
        {
            if (pipe.gameObject.activeSelf == false) // MVP
            {
                return;
            }

            _pool.ReleasePipe(pipe);
        }
    }
}
