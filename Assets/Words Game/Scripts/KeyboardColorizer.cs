using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardColorizer : MonoBehaviour
{
    [Header(" Elements ")]
    private KeyboardKey[] keys;

    [Header(" Settings ")]
    private bool shouldReset;

    private void Awake()
    {
        keys = GetComponentsInChildren<KeyboardKey>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.onGameStateChanged += GameStateChangedCallBack;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallBack;
    }

    public void GameStateChangedCallBack(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Game:

                if(shouldReset)
                   Initialize();
                break;

            case GameState.LevelComplete:
                shouldReset = true;
                break;

            case GameState.Gameover:
                shouldReset = true;
                break;
        }
    }

    public void Initialize()
    {
        for (int i = 0; i < keys.Length; i++)
            keys[i].Initialize();

        shouldReset = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Colorize(string secretWord, string wordToCheck)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            char keyLetter = keys[i].GetLetter();

            for (int j = 0; j < wordToCheck.Length; j++)
            {
                if (keyLetter != wordToCheck[j])
                    continue;

                // the key letter we're pressed is equels to the current wordToCheck letter

                if(keyLetter == secretWord[j])
                {
                    // Valid
                    keys[i].SetValid();
                }
                else if (secretWord.Contains(keyLetter))
                {
                    // Potential
                    keys[i].SetPotential();
                }
                else
                {
                    // Invalid
                    keys[i].SetInvalid();
                }
            }
        }
    }
}
