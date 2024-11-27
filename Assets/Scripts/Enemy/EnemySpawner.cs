using System;
using System.Collections;
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

    public event Action Killed;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Start()
    {
        StartCoroutine(GeneratePipes());
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
        enemy.transform.position = spawnPoint;
        enemy.Init(_bulletPool);
    }

    private void OnEnemyDie(Enemy enemy)
    {
        Debug.Log("On Enemy Die");
        enemy.Died -= OnEnemyDie;
        _enemyPool.ReleaseObjects(enemy);
        Killed?.Invoke();
    }
}
