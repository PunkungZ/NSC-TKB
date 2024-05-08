using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_play : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }   
    public void PlayGamesetting()
    {
        SceneManager.LoadSceneAsync(2);
    }   
    public void PlayGamecreit()
    {
        SceneManager.LoadSceneAsync(3);
    }   
    public void Exit()
    {
        Application.Quit();
    }
    public void station1() 
    {
        SceneManager.LoadScene("Ai");
    }
    public void exit()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
