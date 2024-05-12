using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAWD_Movement : Base_Player
{
    float horizontalMove = 0f;
    bool jump = false;
    public Animator AnimationDragon;


    void Update()
    {
        MovementPlayer2AWD();

        Animation();

    }

    public void Animation()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

            AnimationDragon.SetBool("IsWalking", true);
            
            if(Input.GetKeyUp(KeyCode.A))
            {
                AnimationDragon.SetBool("IsWalking", false);
            }
        }

        
        

        if (Input.GetKeyDown(KeyCode.D))
        {

            AnimationDragon.SetBool("IsWalking", true);

            if (Input.GetKeyUp(KeyCode.D))
            {
                AnimationDragon.SetBool("IsWalking", false);
            }
        }
        

        ///////////////////////////////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            AnimationDragon.SetBool("IsJumping", true);

            if (Input.GetKeyUp(KeyCode.W))
            {
                AnimationDragon.SetBool("IsJumping", false);
            }
        }
        
    }

    
}
