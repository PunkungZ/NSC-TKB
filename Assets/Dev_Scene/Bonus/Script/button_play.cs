using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_play : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(3);
    }   
    public void PlayGamesetting()
    {
        SceneManager.LoadSceneAsync(4);
    }   
    public void PlayGamecreit()
    {
        SceneManager.LoadSceneAsync(5);
    }   
    public void Exit()
    {
        Application.Quit();
    }
}
