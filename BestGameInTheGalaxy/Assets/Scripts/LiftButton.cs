using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButton : MonoBehaviour {

	private bool flag = true;

	void FixUpdate()
	{
		if (Input.GetKeyUp (KeyCode.E)) 
		{
			if (flag == true) 
			{
				TransformLiftUp ();
				flag = false;
			}
			else 
			{
				TransformLiftDown();
				flag = true;
			}
		}
	}

	void TransformLiftUp()
	{
		
	}

	void TransformLiftDown()
	{
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "LiftButton") 
		{
			FixUpdate ();
		}
	}
}
