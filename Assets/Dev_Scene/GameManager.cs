using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform player1SpawnPoint;
    [SerializeField] private Transform player2SpawnPoint;
    [SerializeField] private GameObject[] characterPrefabs;

    void Start()
    {
        int player1Index = PlayerPrefs.GetInt("Player1Character", 0);
        int player2Index = PlayerPrefs.GetInt("Player2Character", 0);

        Instantiate(characterPrefabs[player1Index], player1SpawnPoint.position, Quaternion.identity);
        Instantiate(characterPrefabs[player2Index], player2SpawnPoint.position, Quaternion.identity);
    }
}
