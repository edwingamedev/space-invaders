using EdwinGameDev.Barriers;
using EdwinGameDev.Enemies;
using EdwinGameDev.Events;
using EdwinGameDev.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // GamePlay
    private int score;
    [SerializeField] private int lives;
    private int maxLives;

    [SerializeField] private float secondsToRespawn;
    [SerializeField] private float secondsToNextStage;
    [SerializeField] private List<Barrier> barriers;

    [SerializeField] private ScriptableEvent<bool> onStageClear;
    private bool gameStarted;

    // Enemies
    [SerializeField] private ScriptableEvent<int> onEnemyDied;
    [SerializeField] private GameObject enemiesClusterPrefab;
    private EnemyCluster enemies;

    // UI
    [SerializeField] private ScriptableEvent<int> onScoreChange;
    [SerializeField] private ScriptableEvent<int> onLivesChange;
    [SerializeField] private ScriptableEvent<bool> onGameEnded;

    // Player
    [SerializeField] private ScriptableEvent<bool> onPlayerDied;
    [SerializeField] private GameObject playerPrefab;
    private Player player;

    private void Awake()
    {
        maxLives = lives;

        onEnemyDied.Subscribe(AddPoints);
        onPlayerDied.Subscribe(ValidatePlayerScore);
        onStageClear.Subscribe(NextStage);
    }

    private void NextStage(bool value)
    {
        Invoke("PrepareStage", secondsToNextStage);
    }

    private void PrepareStage()
    {
        enemies.Respawn();

        ResetBarriers();
    }

    private void Update()
    {
        if (!gameStarted && Input.GetButtonDown("Submit"))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        // Player
        if (player == null)
        {
            player = Instantiate(playerPrefab).GetComponent<Player>();
        }
        else
        {
            player.Respawn();
        }

        // Enemies
        if (enemies == null)
        {
            enemies = Instantiate(enemiesClusterPrefab).GetComponent<EnemyCluster>();
        }
        else
        {
            enemies.Respawn();
        }

        // Reset Score
        SetScore(0);

        // Reset Lives
        SetLives(maxLives);

        // Barriers
        ResetBarriers();

        onGameEnded.Notify(false);

        gameStarted = true;
    }

    private void ResetBarriers()
    {
        foreach (var barrier in barriers)
        {
            barrier.Initialize();
        }
    }

    private void SetLives(int value)
    {
        lives = value;

        if (lives < 0)
        {
            lives = 0;
        }

        onLivesChange.Notify(lives);
    }

    private void SetScore(int value)
    {
        score = value;

        onScoreChange.Notify(score);
    }

    public void ValidatePlayerScore(bool value)
    {
        SetLives(--lives);

        player.gameObject.SetActive(false);

        // if has lives, respawn
        if (lives > 0)
        {
            enemies.gameObject.SetActive(false);
            Invoke("Respawn", secondsToRespawn);
        }
        else // GAME OVER
        {
            // reset lives
            GameOver();
        }
    }

    private void Respawn()
    {
        enemies.gameObject.SetActive(true);

        player.Respawn();
    }

    private void GameOver()
    {
        enemies.gameObject.SetActive(false);

        gameStarted = false;

        onGameEnded.Notify(true);
    }

    public void AddPoints(int value)
    {
        SetScore(score + value);
    }
}