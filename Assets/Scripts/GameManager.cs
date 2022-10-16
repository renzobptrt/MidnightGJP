using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Posibles estados del videojuego
public enum GameState
{
    inGame,
    inGameOver,
    inMenuInventory
}

public class GameManager : MonoBehaviour
{

    public static GameManager sharedInstance;

    //Variable para saber en que estado del juego nos encontramos
    public GameState gameState = GameState.inGame;

    public Canvas menuCanvas, inGameCanvas, gameOverCanvas;

    void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        //GameOverCanvas
        Button buttonBackToMainMenu = gameOverCanvas.transform.GetChild(0).Find("Button_MainMenu").GetComponent<Button>();
        buttonBackToMainMenu.StopAllCoroutines();
        buttonBackToMainMenu.onClick.AddListener(() => GoToMainMenu());

        Button buttonRepeat = gameOverCanvas.transform.GetChild(0).Find("Button_Repeat").GetComponent<Button>();
        buttonRepeat.StopAllCoroutines();
        buttonRepeat.onClick.AddListener(() => ResetGame());

        StartGame();

    }

    public void StartGame()
    {
        setGameState(GameState.inGame);
    }

    public void GameOver()
    {
        setGameState(GameState.inGameOver);
    }

    private void ResetGame()
    {
        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void setGameState(GameState newGameState)
    {
        if (newGameState == GameState.inGame)
        {
            //Se prepara la escena para jugar 
            menuCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            inGameCanvas.enabled = true;
        }
        else if (newGameState == GameState.inGameOver)
        {
            //Se prepara la escena para GameOver
            menuCanvas.enabled = false;
            gameOverCanvas.enabled = true;
            inGameCanvas.enabled = false;
        }
        else if (newGameState == GameState.inMenuInventory)
        {
            menuCanvas.enabled = true;
            gameOverCanvas.enabled = false;
            inGameCanvas.enabled = false;
        }
        this.gameState = newGameState;
    }
}
