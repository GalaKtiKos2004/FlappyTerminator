using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Pool<Enemy> _enemysPool;
    [SerializeField] private Pool<Bullet> _playerBullets;
    [SerializeField] private Pool<Bullet> _enemyBullets;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Window _startScreen;
    [SerializeField] private Window _endGameScreen;

    private void OnEnable()
    {
        _startScreen.ButtonClicked += OnPlayButtonClick;
        _endGameScreen.ButtonClicked += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.ButtonClicked -= OnPlayButtonClick;
        _endGameScreen.ButtonClicked -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _endGameScreen.Close();
    }

    private void OnGameOver()
    {
        _endGameScreen.Open();
        Time.timeScale = 0;
        _enemySpawner.ClearEnemys();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        _enemysPool.Clear();
        _enemyBullets.Clear();
        _playerBullets.Clear();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
    }
}
