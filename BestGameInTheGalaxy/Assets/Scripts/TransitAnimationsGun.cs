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
        mo = GetComponent<Move>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(mo.isGrounded && Input.GetMouseButton(0))
        {
            anima.SetBool("cFire", true);
        }
        else
        {
            anima.SetBool("cFire", false);
        }
	}
}
