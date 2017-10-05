using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitAnimations : MonoBehaviour
{
    //ссылочная переменная для аниматора
    Animator anim;
    //ссылочная переменная для rigidbody2D
    Rigidbody2D rb;
    Move m;
    public bool CheckDoubleJump=false, ContinueFrame=false;

    void Start()
    {
        
        //делаем ссылку на аниматор
        anim = GetComponent<Animator>();
        //делаем ссылку на Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        //делаем ссылку на Move
        m = GetComponent<Move>();

    }

    void Update()
    {
        if (m.isGrounded)
        {
            if (CheckDoubleJump)
            {
                CheckDoubleJump = false;
                ContinueFrame = false;
            }
            
            //меняем параметр isJumping на false
            anim.SetBool("isJumping", false);
            anim.SetBool("isJumping1", true);
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("Shot", true);
            }
            else
            {
                anim.SetBool("Shot", false);
            }
                
            
            
            //меняем параметр speed. Используем абсолютное значение вектора скорости по х
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            // если крыса не на земле
        }
        else
        {
            
            if (m.DoubleJump && !CheckDoubleJump)
            {
                if(Input.GetMouseButton(0))
                {
                    anim.SetBool("Shot", true);
                }
                if(!ContinueFrame)
                {
                    anim.SetBool("isJumping1", true);
                    ContinueFrame = true;
                    
                }
                else
                {
                    anim.SetBool("isJumping1", false);
                    anim.SetBool("isJumping", true);
                    
                    CheckDoubleJump = true;
                }   
            }
            else
            {
                if(!CheckDoubleJump && !ContinueFrame )
                {
                    anim.SetFloat("Speed", 0);
                    //меняем параметр isJumping на true
                    anim.SetBool("isJumping", true);
                    anim.SetBool("isJumping1", false);
                }
                
            }
            
        }
        
    }
}
