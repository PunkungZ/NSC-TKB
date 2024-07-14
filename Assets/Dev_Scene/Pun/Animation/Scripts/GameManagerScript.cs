using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    { 
        gameOverUI.SetActive(true);    
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void mainmenu() 
    {
        SceneManager.LoadScene("UI-start");
        Time.timeScale = 1f;
    }

    public void leave() 
    {
        Application.Quit();
        Debug.Log("Leave");
    }
}
