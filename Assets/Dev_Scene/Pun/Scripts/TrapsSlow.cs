using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsSlow : Base_Player
{
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("enemy"))
        {
            moveSpeed = 3f;
        }
    }
}
