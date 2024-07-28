using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public Image player1Image;
    public Image player2Image;

    public Sprite[] player1CharacterSprites;
    public Sprite[] player2CharacterSprites;

    public GameObject[] player1Prefabs;
    public GameObject[] player2Prefabs;

    private int player1Index;
    private int player2Index;

    public string GameScene;

    public void Start()
    {
        // สุ่มตัวละครที่ไม่ซ้ำกันสำหรับผู้เล่น 1 และผู้เล่น 2
        player1Index = Random.Range(0, player1CharacterSprites.Length);
        do
        {
            player2Index = Random.Range(0, player2CharacterSprites.Length);
        } while (player2CharacterSprites[player2Index] == player1CharacterSprites[player1Index]);

        UpdatePlayer1Character();
        UpdatePlayer2Character();
    }

    public void OnPlayer1Next()
    {
        int newIndex = (player1Index + 1) % player1CharacterSprites.Length;
        if (player2CharacterSprites[player2Index] == player1CharacterSprites[newIndex])
        {
            newIndex = (newIndex + 1) % player1CharacterSprites.Length;
        }
        player1Index = newIndex;
        UpdatePlayer1Character();
    }

    public void OnPlayer1Previous()
    {
        int newIndex = (player1Index - 1 + player1CharacterSprites.Length) % player1CharacterSprites.Length;
        if (player2CharacterSprites[player2Index] == player1CharacterSprites[newIndex])
        {
            newIndex = (newIndex - 1 + player1CharacterSprites.Length) % player1CharacterSprites.Length;
        }
        player1Index = newIndex;
        UpdatePlayer1Character();
    }

    public void OnPlayer2Next()
    {
        int newIndex = (player2Index + 1) % player2CharacterSprites.Length;
        if (player2CharacterSprites[newIndex] == player1CharacterSprites[player1Index])
        {
            newIndex = (newIndex + 1) % player2CharacterSprites.Length;
        }
        player2Index = newIndex;
        UpdatePlayer2Character();
    }

    public void OnPlayer2Previous()
    {
        int newIndex = (player2Index - 1 + player2CharacterSprites.Length) % player2CharacterSprites.Length;
        if (player2CharacterSprites[newIndex] == player1CharacterSprites[player1Index])
        {
            newIndex = (newIndex - 1 + player2CharacterSprites.Length) % player2CharacterSprites.Length;
        }
        player2Index = newIndex;
        UpdatePlayer2Character();
    }

    private void UpdatePlayer1Character()
    {
        player1Image.sprite = player1CharacterSprites[player1Index];
    }

    private void UpdatePlayer2Character()
    {
        player2Image.sprite = player2CharacterSprites[player2Index];
    }

    public void OnPlayButton()
    {
        // Save selected characters
        PlayerPrefs.SetInt("Player1Character", player1Index);
        PlayerPrefs.SetInt("Player2Character", player2Index);

        // Save the prefabs as well
        PlayerPrefs.SetString("Player1Prefab", player1Prefabs[player1Index].name);
        PlayerPrefs.SetString("Player2Prefab", player2Prefabs[player2Index].name);

        // Load the next scene
        SceneManager.LoadScene(GameScene);
    }
}

