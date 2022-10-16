using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewInGame : MonoBehaviour
{
    public static ViewInGame sharedInstance;

    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI valueProgressText;
    public TextMeshProUGUI maxScoreText;

    public Slider sliderProgress;

    public Transform target = null;

    void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {

    }

    void Update()
    {
        if (GameManager.sharedInstance.gameState == GameState.inGame ||
           GameManager.sharedInstance.gameState == GameState.inGameOver)
        {
            //int coins = GameManager.sharedInstance.collectedCoin;
            //this.coinsText.text = coins.ToString();

        }
        if (GameManager.sharedInstance.gameState == GameState.inGame)
        {
            // float distance = PlayerContoller.sharedInstance.GetDistance();
            //this.scoreText.text = distance.ToString("f2");

            // float maxScore = PlayerPrefs.GetFloat("maxScore", 0);
            // this.maxScoreText.text = maxScore.ToString("f2");
            
            if(finalPosition.x - target.position.x >= 0)
            {
                sliderProgress.value = (Mathf.Abs(finalPosition.x - startPosition.x) - Mathf.Abs(finalPosition.x - target.position.x))
/ Mathf.Abs(finalPosition.x - startPosition.x);

                float currentValue = sliderProgress.value * 100f;
                int valueInt = (int)currentValue;
                this.valueProgressText.text = valueInt.ToString() + " %";
            }

        }
    }

    public void SetStartPosition(Transform newStartPosition)
    {
        if (newStartPosition != null)
        {
            startPosition = newStartPosition.position;
        }
    }

    public void SetFinalPosition(Transform newFinalPosition)
    {
        if (newFinalPosition != null)
        {
            finalPosition = newFinalPosition.position;
        }
    }

    private Vector2 startPosition = Vector2.zero;
    private Vector2 finalPosition = Vector2.zero;
    private int InitialNumber = 0;
    private int FinalNumber = 0;
    private int initialDistance = 0;
}
