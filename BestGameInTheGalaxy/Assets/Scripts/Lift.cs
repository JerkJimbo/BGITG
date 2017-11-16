using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

	private bool flag = true;
	public float speed = 0.1f;
	private Vector3 PosDown = new Vector3 (17,-2.9f, 0);
	private Vector3 PosUp = new Vector3 (17, 2f, 0);


	void Update () 
	{
		if (Input.GetKeyUp (KeyCode.E)) 
		{
			if (flag == true) {
				TransformerKeyDown ();
				flag = false;
			} 
			else 
			{
				TransformerKeyUp ();
				flag = true;
			}
		}
	}

	void TransformerKeyDown()
	{
		this.transform.position += this.transform.up * Input.GetAxis ("Vertical") * speed * Time.deltaTime;
	}

	void TransformerKeyUp()
	{
		this.transform.position += this.transform.position * Input.GetAxis ("Vertical") * speed * Time.deltaTime;
	}
}
