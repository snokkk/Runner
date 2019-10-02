using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    private int coins = 0;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        Time.timeScale = 0;
    }

    public void IsWinGame(bool isWin)
    {
        Time.timeScale = 0;
        UI.instance.OpenEndGamePanel(isWin);
    }

    public void PlusCoin()
    {
        coins++;
    }

    public int GetCoins()
    {
        return coins;
    }

}
