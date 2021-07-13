
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Joystick joystick;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    
    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (joystick.Horizontal>=1.2f)
        {
            horizontalMove = runSpeed;
        }
        else if(joystick.Horizontal <=1.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0;
        }

        float verticalMove = joystick.Vertical;
        horizontalMove = joystick.Horizontal*runSpeed;
        if(verticalMove>=.5f)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if(verticalMove<=-.5f)
        {
            crouch = true;
        }else
        {
            crouch = false;
        }
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouch", isCrouching);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }



}
