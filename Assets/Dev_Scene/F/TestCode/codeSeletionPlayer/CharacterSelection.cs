using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public Image player1Image;
    public Image player2Image;

    public string GameScene;

    public Sprite[] characterSprites;

    private int player1Index = 0;
    private int player2Index = 0;

    public void Start()
    {
        player1Index = Random.Range(0, characterSprites.Length);
        do
        {
            player2Index = Random.Range(0, characterSprites.Length);
        } while (player2Index == player1Index);

        UpdatePlayer1Character();
        UpdatePlayer2Character();
    }


    public void OnPlayer1Next()
    {
        int newIndex = (player1Index + 1) % characterSprites.Length;
        if (newIndex == player2Index)
        {
            newIndex = (newIndex + 1) % characterSprites.Length;
        }
        player1Index = newIndex;
        UpdatePlayer1Character();
    }

    public void OnPlayer1Previous()
    {
        int newIndex = (player1Index - 1 + characterSprites.Length) % characterSprites.Length;
        if (newIndex == player2Index)
        {
            newIndex = (newIndex - 1 + characterSprites.Length) % characterSprites.Length;
        }
        player1Index = newIndex;
        UpdatePlayer1Character();
    }

    public void OnPlayer2Next()
    {
        int newIndex = (player2Index + 1) % characterSprites.Length;
        if (newIndex == player1Index)
        {
            newIndex = (newIndex + 1) % characterSprites.Length;
        }
        player2Index = newIndex;
        UpdatePlayer2Character();
    }

    public void OnPlayer2Previous()
    {
        int newIndex = (player2Index - 1 + characterSprites.Length) % characterSprites.Length;
        if (newIndex == player1Index)
        {
            newIndex = (newIndex - 1 + characterSprites.Length) % characterSprites.Length;
        }
        player2Index = newIndex;
        UpdatePlayer2Character();
    }

    private void UpdatePlayer1Character()
    {
        player1Image.sprite = characterSprites[player1Index];
    }

    private void UpdatePlayer2Character()
    {
        player2Image.sprite = characterSprites[player2Index];
    }

    public void OnPlayButton()
    {
        // Save selected characters
        PlayerPrefs.SetInt("Player1Character", player1Index);
        PlayerPrefs.SetInt("Player2Character", player2Index);

        // Load the next scene
        SceneManager.LoadScene(GameScene);
    }
}

