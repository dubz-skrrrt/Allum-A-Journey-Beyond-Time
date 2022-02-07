using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState state;
    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        Instance = this;
        Cursor.visible = false;
    }
    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {

        }

        OnGameStateChanged?.Invoke(newState);
    }
}


public enum GameState
{
    Pause
}
