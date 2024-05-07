using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float reminingTime;
    public GameManagerScript gameManager;
    public GameObject gameOverUI;

    bool isdead;

    void Update()
    {
        if (reminingTime > 0) 
        {
            reminingTime -= Time.deltaTime;        
        }
        else if (reminingTime < 0)
        {
            reminingTime = 0;
            // GameOver();
            timerText.color = Color.red;
        }

        if (reminingTime <= 0 && !isdead)
        {
            isdead = true;
            gameManager.gameOver();
        }
        int minutes = Mathf.FloorToInt(reminingTime / 60);
        int seconds = Mathf.FloorToInt(reminingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",  minutes, seconds);
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }


}
