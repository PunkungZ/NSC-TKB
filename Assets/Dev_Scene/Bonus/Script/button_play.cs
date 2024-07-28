using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_play : MonoBehaviour

{
    [SerializeField] Animator transitionAnim;
    public void PlayGamest()
    {
        StartCoroutine(Loadlevel1());

    }   

    IEnumerator Loadlevel1()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(1);
        transitionAnim.SetTrigger("Start");
    }
    //public void PlayGamesetting()
    //{
        //SceneManager.LoadSceneAsync(2);
    //}
    
    public void PlayGames()
    {
        SceneManager.LoadSceneAsync("cutscene");
    }  
    
    public void Exit()
    {
        Application.Quit();
    }

    public void station1() 
    {
        SceneManager.LoadScene("Map Complete");
    }

    public void exit()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
