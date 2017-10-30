using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Move : MonoBehaviour
{

    //в инспекторе мы можем выбрать, какие слои будут землёй
    public LayerMask WhatIsGround;
    //позиция для проверки касания земли
    public Transform GroundCheck;
    //переменная, которая будет true, если крыса находится на земле
    public bool isGrounded, DoubleJump;
    //значение величины силы
    public float jumpForce, djc=1f;
    //переменная для скорости движения, высоты двойного прыжка
    public float speed;
    //ссылочная переменная для компонента Rigidbody2D
    Rigidbody2D rb;
    bool isLookingLeft=false;

    void Start()
    {
        //делаем ссылку на Rigidbody2D
        rb = GetComponent<Rigidbody2D>();



    }

    //я буду использовать Update() для более точного определения прыжка
    void Update()
    {
        //проверка, нажат-ли прыжок и находится-ли крыса на земле
        if (Input.GetButtonDown("Jump") && (isGrounded || !DoubleJump))
        {
            if (isGrounded == true)//проверка на наличие второго прыжка
            {
                //применяем силу на Rigidbody2D вдоль оси Y для прыжка
                rb.AddForce(Vector2.up * jumpForce * djc, ForceMode2D.Impulse);
                isGrounded = false;
                djc = 0.8f;
            }
            else
            {

                rb.velocity = Vector3.zero;
                //применяем силу на Rigidbody2D вдоль оси Y для прыжка
                rb.AddForce(Vector2.up * jumpForce * djc, ForceMode2D.Impulse);
                
                djc = 1f;
                DoubleJump = true;
            }
            
        }
    }

    void FixedUpdate()
    {  
        //изменяем переменную, зависящую от результата Physics2D.OverlapPoint
        isGrounded = Physics2D.OverlapPoint(GroundCheck.position, WhatIsGround);
        if(isGrounded == true)
        {
            djc = 1f;
            DoubleJump = false;
        }
        //декларация переменной с её инициализацией значением полученным с горизонтальной оси (значение лежит в области между -1 и 1)
        float x = Input.GetAxis("Horizontal");
        //декларация локального вектора и инициализация посчитанным значением
        //x: значение от InputManager * speed
        //y: принять текущее значение, мы не будем его менять, из-за использования силы тяжести
        //z: должно быть равно нулю, нам не нужно движение по оси Z
        Vector3 move = new Vector3(x * speed, rb.velocity.y, 0f);
        //Изменить скорость игрока на вычисленный вектор
        rb.velocity = move;
        if(x>0 && isLookingLeft)
        {
            TurnThePlayer();
        }
        if (x<0 && !isLookingLeft)
        {
            TurnThePlayer();
        }
    }
    void TurnThePlayer ()
    {
        isLookingLeft = !isLookingLeft;
        //поворт игрока через инвертацию размера по оси x
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }




}
