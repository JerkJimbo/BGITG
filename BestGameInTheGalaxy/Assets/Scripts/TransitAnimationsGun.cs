using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitAnimationsGun : MonoBehaviour {

    Animator anima;
    Rigidbody2D rb;
    Move mo;
    FireScript2D FS2D;

	void Start ()
    {
        //делаем ссылку на аниматор
        anima = GetComponent<Animator>();
        //делаем ссылку на Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        //делаем ссылку на Move
        mo = GameObject.Find("Player").GetComponent<Move>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(!mo.isGrounded && Input.GetMouseButton(0))
        {
            Debug.Log(mo.isGrounded);
            anima.SetBool("cFire", true);
            Debug.Log(anima.GetBool("cFire"));
        }
        else
        {
            anima.SetBool("cFire", false);
        }
	}
}
