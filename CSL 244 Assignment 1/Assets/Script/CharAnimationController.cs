using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimationController : MonoBehaviour
{
    public Animator charAnimator;

    public bool canJump = false;
    public bool canFall = false;
    public float jumpTime = 0.5f;
    public float jumpTimer = 0;

    public float fallingTime = 0.5f;
    public float fallingTimer = 0;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            charAnimator.SetBool("IsWalking",true);
        }
        else
        {
            charAnimator.SetBool("IsWalking",false);
        }
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            charAnimator.SetBool("IsRunning",true);
        }
        else
        {
            charAnimator.SetBool("IsRunning",false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump==false && canFall == false)
        {
            charAnimator.SetBool("IsJumping",true);
            canJump = true;
            jumpTimer = 0;
        }

        if (canJump)
        {
            jumpTimer += Time.deltaTime;
        }

        if (jumpTimer > jumpTime)
        {
            jumpTimer = 0;
            canJump = false;
            charAnimator.SetBool("IsJumping",false);
            charAnimator.SetBool("IsFalling",true);
            canFall = true;
            fallingTimer = 0;
        }

        if (canFall)
        {
            
            fallingTimer += Time.deltaTime;
        }

        if (fallingTimer > fallingTime)
        {
            fallingTimer = 0;
            charAnimator.SetBool("IsFalling",false);
            charAnimator.SetBool("Landed",true);
            canFall = false;
            canJump = false;
            
        }




    }
}
