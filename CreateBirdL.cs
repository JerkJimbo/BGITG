using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBirdL : MonoBehaviour {


	//создание птички для полета влево
	//как и CreateBird, но на противоположной стороне карты




	public GameObject FBird;

	void Start () {
		StartCoroutine (Inst());
	}

	IEnumerator Inst ()
	{
		float SpawnTime = Random.Range (7.0f, 20.0f); 
		Vector3 position = new Vector3 (34, Random.Range(0.5f,3.3f), 0);
		yield return new WaitForSeconds (SpawnTime);
		GameObject FB = Instantiate(FBird,position,Quaternion.identity) as GameObject;
		Destroy (FB, 15);
		Repeat ();
	}

	void Repeat()
	{
		StartCoroutine (Inst());
	}
}
