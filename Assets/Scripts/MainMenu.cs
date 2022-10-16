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
    public Button buttonBackMainMenu = null;

    public RectTransform rtMainPanel = null;
    public RectTransform rtPowerupsPanel = null;

    public List<Button> buttonsPowerups = new List<Button>();

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
            buttonViewInventory.onClick.AddListener(() => {
                rtMainPanel.anchoredPosition = new Vector2(2000, 0);
                rtPowerupsPanel.anchoredPosition = Vector2.zero;
            });
        }

        if(buttonBackMainMenu != null)
        {
            buttonBackMainMenu.StopAllCoroutines();
            buttonBackMainMenu.onClick.AddListener(() => {
                rtMainPanel.anchoredPosition = Vector2.zero; 
                rtPowerupsPanel.anchoredPosition = new Vector2(2000, 0);
            });
        }

        if(buttonsPowerups.Count > 0)
        {
            for(int i=0; i<buttonsPowerups.Count; i++)
            {
                int temp = i;
                buttonsPowerups[temp].StopAllCoroutines();
                buttonsPowerups[temp].onClick.AddListener(() => SetPowerups(temp));
            }
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

    private void SetPowerups(int index)
    {
        Image currentImage = buttonsPowerups[index].transform.GetChild(0).GetComponent<Image>();
        Color currentColor = currentImage.color;

        int setCurrentState = currentColor == Color.white ? 0 : 1;
        string currentPowerupIndex = "Powerup_" + index;
        PlayerPrefs.SetInt(currentPowerupIndex, setCurrentState);

        currentImage.color = setCurrentState == 0 ? Color.black : Color.white; 
    }
}
