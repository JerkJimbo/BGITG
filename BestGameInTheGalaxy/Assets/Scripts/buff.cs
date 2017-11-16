using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buff : MonoBehaviour {

	public Move m;
	public float MaxSpeed = 7;
	private float SaveSpeed;
	void Start()
	{
		m = GameObject.Find ("Player").GetComponent<Move> ();
		SaveSpeed = m.speed;
	}

	IEnumerator Inst()
	{
		yield return new WaitForSeconds (10);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "buff") 
		{
			m.speed = MaxSpeed;
			Destroy (other.gameObject);
			StartCoroutine (Inst());
			m.speed = SaveSpeed;
		}
	}
}
