using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public static UI instance = null;

    [Header("Text fields")]
    [SerializeField] private Text progressPercentText;
    [SerializeField] private Text scoreText, finalScoreText;
    [SerializeField] private Text timerText;
    [SerializeField] private Text endGameText;

    [Header("UI panels")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject gameUiPanel;

    [Header("Other")]
    [SerializeField] private GameObject messageBox;
    [SerializeField] private Slider pickupProgressBar;
    private int numberOfCoins;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        numberOfCoins = gameObject.GetComponent<CoinSpawner>().numberOfCoins + 1;
    }

    public void Update()
    {
        ShowCurrentScore();
    }

    public void ShowTimer(int time)
    {
        timerText.text = time + "";
    }

    public void ShowCurrentScore() 
    {
        int score = GameManager.instance.GetCoins();
        scoreText.text = "Coins " + score + "/" + numberOfCoins;
    }

    public void ShowFinalScore()
    {
        int score = GameManager.instance.GetCoins();
        finalScoreText.text = "Coins " + score + "/" + numberOfCoins;
    }

    public void OpenEndGamePanel(bool isWin)
    {
        ShowFinalScore();

        if (isWin)
        {
            endGameText.text = "You win!";
        }
        else if (!isWin)
        {
            endGameText.text = "Game Over"; 
        }

        endGamePanel.SetActive(true);
    }

    public void OnClickStart()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickRestart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}
