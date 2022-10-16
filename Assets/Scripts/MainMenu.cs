using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button buttonStartGame = null;
    public Button buttonQuitGame = null;
    public Button buttonViewInventory = null;

    void Start()
    {
        if(buttonStartGame != null)
        {
            buttonStartGame.StopAllCoroutines();
            buttonStartGame.onClick.AddListener(() => StartGame());
        }

        if(buttonQuitGame!= null)
        {
            buttonQuitGame.StopAllCoroutines();
            buttonQuitGame.onClick.AddListener(() => ExitGame());
        }

        if(buttonViewInventory != null)
        {
            buttonViewInventory.StopAllCoroutines();
            //Mostrar GUI Inventario Powerups
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameLevel");
    }


}
