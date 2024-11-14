using System;
using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> Collided;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            Collided?.Invoke(interactable);
        }
    }
}
