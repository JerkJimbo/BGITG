using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderManagerV2 : MonoBehaviour {

	public float speed;
	private bool isTrigger = false;
	private Rigidbody2D PlayerRigidBody;


	void OnTriggerEnter(Collider2D other)
	{
		if (other.gameObject.tag == "Ladder") 
		{
			
		}
	}

	void OffLadder()
	{
		PlayerRigidBody.isKinematic = false;
		PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;
	}

	void OnLadder()
	{
		PlayerRigidBody.isKinematic = true;
	}
}
