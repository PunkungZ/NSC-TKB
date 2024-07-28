using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform player1SpawnPoint;
    [SerializeField] private Transform player2SpawnPoint;
    [SerializeField] private GameObject[] player1Prefabs;
    [SerializeField] private GameObject[] player2Prefabs;

    void Start()
    {
        int player1Index = PlayerPrefs.GetInt("Player1Character", 0);
        int player2Index = PlayerPrefs.GetInt("Player2Character", 0);

        string player1PrefabName = PlayerPrefs.GetString("Player1Prefab");
        string player2PrefabName = PlayerPrefs.GetString("Player2Prefab");

        GameObject player1Prefab = System.Array.Find(player1Prefabs, prefab => prefab.name == player1PrefabName);
        GameObject player2Prefab = System.Array.Find(player2Prefabs, prefab => prefab.name == player2PrefabName);

        Instantiate(player1Prefab, player1SpawnPoint.position, Quaternion.identity);
        Instantiate(player2Prefab, player2SpawnPoint.position, Quaternion.identity);
    }
}
