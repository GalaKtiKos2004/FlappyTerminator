using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    private int _score;

    public event Action<int> ScoreChanged;

    private void Awake()
    {
        _score = 0;
    }

    private void OnEnable()
    {
        _spawner.Killed += Add;
    }

    private void OnDisable()
    {
        _spawner.Killed -= Add;
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    private void Add()
    {
        ScoreChanged?.Invoke(++_score);
    }
}
