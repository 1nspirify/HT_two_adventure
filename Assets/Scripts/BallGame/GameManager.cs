using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private string _startGameText = "A,D  - move\n Space - Jump\n R - restart game";
    private string _victoryText = "You win!";
    private string _gameOverText = "Game Over!, Time has finished!";

    [SerializeField] private int _score;
    [SerializeField] private int _scoreToWin = 15;
    [Space(15)]
    [SerializeField] private float _timer = 30f;
    [SerializeField] private List<GameObject> _collectableItems;

    private KeyCode _restartButton = KeyCode.R;
    
    private bool _isGameOver;
    private bool _isPlayerWon;
    
    private void Awake()
    {
        Debug.LogWarning(_startGameText);
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            GameOver();
        }

        if (_score >= _scoreToWin)
        {
            PlayerWon();
        }

        if (SessionHasFinished())
        {
            RestartGame();
        }
    }

    private bool SessionHasFinished() => (_isGameOver || _isPlayerWon) && Input.GetKeyDown(KeyCode.R);

    private void PlayerWon()
    {
        Time.timeScale = 0;
        Debug.LogWarning(_victoryText);
        _isPlayerWon = true;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        Debug.LogWarning(_gameOverText);
        _isGameOver = true;
    }

    public void AddCoin()
    {
        _score++;
    }

    private void RestartGame()
    {
        foreach (GameObject item in _collectableItems)
        {
            item.SetActive(true);
        }

        _timer = 30f;
        _score = 0;

        _isGameOver = false;
        _isPlayerWon = false;

        Time.timeScale = 1;
    }
}