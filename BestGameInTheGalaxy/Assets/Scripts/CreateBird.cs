using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBird : MonoBehaviour {

	public GameObject FBird;

	void Start () {
		StartCoroutine (Inst());
	}

	IEnumerator Inst ()
	{
		float SpawnTime = Random.Range (7.0f, 20.0f);                   //время спауна
		Vector3 position = new Vector3 (-10,Random.Range(0.5f,3.3f),0); //позиция по У
		yield return new WaitForSeconds (SpawnTime);                    //ожидание спауна
		GameObject FB = Instantiate(FBird,position,Quaternion.identity) as GameObject;//создание птички
		Destroy (FB, 15); //удаление через 15 сек
		Repeat ();
	}

	void Repeat() //повтор спауна
	{
		StartCoroutine (Inst());
	}
}
