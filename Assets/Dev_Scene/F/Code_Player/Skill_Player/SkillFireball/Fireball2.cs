using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}