using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCreaBox : MonoBehaviour
{
    public GameObject blockPrefab;
    private GameObject[] blocks = new GameObject[3];
    private int numBlocks = 0;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            blocks[i] = Instantiate(blockPrefab, new Vector3(-100f, 0f, 0f), Quaternion.identity);
            blocks[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numBlocks < 3)
        {
            blocks[numBlocks].transform.position = transform.position + new Vector3(1, 0, 0);
            blocks[numBlocks].SetActive(true);
            numBlocks++;
        }

        for (int i = 0; i < 3; i++)
        {
            if (blocks[i].activeSelf)
            {
                blocks[i].transform.position += Vector3.left * Time.deltaTime;
            }
        }
    }
}
