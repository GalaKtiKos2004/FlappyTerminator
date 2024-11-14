using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
[RequireComponent(typeof(ScoreCounter))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private BirdCollisionHandler _collisionHandler;
    private ScoreCounter _counter;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        _collisionHandler = GetComponent<BirdCollisionHandler>();
        _counter = GetComponent<ScoreCounter>();
    }

    private void OnEnable()
    {
        _collisionHandler.Collided += Collision;
    }

    private void OnDisable()
    {
        _collisionHandler.Collided -= Collision;
    }

    public void Reset()
    {
        _mover.Reset();
        _counter.Reset();
    }

    private void Collision(IInteractable interactable)
    {
        if (interactable is Pipe)
        {
            GameOver?.Invoke();
        }
        else if (interactable is ScoreZone)
        {
            _counter.Add();
        }
    }
}
