using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private int _poolMaxSize;
    [SerializeField] private EnemysPool _enemyPool;
    [SerializeField] private BulletPool _bulletPool;

    private WaitForSeconds _wait;

    private List<Enemy> _enemies;

    public event Action Killed;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
        _enemies = new List<Enemy>();
    }

    private void Start()
    {
        StartCoroutine(GeneratePipes());
    }

    public void ClearEnemys()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Died -= OnEnemyDie;
        }

        _enemies.Clear();
    }

    private IEnumerator GeneratePipes()
    {
        while (enabled)
        {
            Spawn();
            yield return _wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy enemy = _enemyPool.GetObjects();
        enemy.Died += OnEnemyDie;
        enemy.Released += OnEnemyReleased;
        enemy.transform.position = spawnPoint;
        enemy.Init(_bulletPool);
        _enemies.Add(enemy);
    }

    private void OnEnemyDie(Enemy enemy)
    {
        Debug.Log("Enemy Die Handler");
        _enemyPool.ReleaseObjects(enemy);
        _enemies.Remove(enemy);
        Killed?.Invoke();
    }

    private void OnEnemyReleased(Enemy enemy)
    {
        enemy.Died -= OnEnemyDie;
        enemy.Released -= OnEnemyReleased;
    }
}
