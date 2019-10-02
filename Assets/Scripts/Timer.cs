using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField] private int roundTime = 120;

    private void Start()
    {
        StartTimer();
    }

    void StartTimer()
    {
        StartCoroutine(TimeToEnd());
    }

    public IEnumerator TimeToEnd()
    {
        while (roundTime != 0)
        {
            UI.instance.ShowTimer(roundTime);

            roundTime--;
            yield return new WaitForSeconds(1f);
        }
        GameManager.instance.IsWinGame(false);
    }

}
