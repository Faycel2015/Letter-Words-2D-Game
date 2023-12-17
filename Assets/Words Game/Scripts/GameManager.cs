using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState { Menu, Game, LevelComplete, Gameover, Idle }

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header(" Settings ")]
    private GameState gameState;

    [Header(" Events ")]
    public static Action<GameState> onGameStateChanged;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextButtonCallBack()
    {
        SetGameState(GameState.Game);
    }

    public bool IsGameState()
    {
        return gameState == GameState.Game;
    }
}
