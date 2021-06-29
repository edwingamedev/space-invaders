using EdwinGameDev.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public int score;
    public ScriptableEvent<int> onEnemyDied;
    public ScriptableEvent<int> onScoreChange;

    private void Start()
    {
        onEnemyDied.Attach(AddPoints);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddPoints(10);
        }
    }

    public void AddPoints(int value)
    {
        score += value;

        onScoreChange?.Trigger(score);
    }
}