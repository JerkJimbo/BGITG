using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBuff : MonoBehaviour {

	public int HPRes;
	public HealthScript php;

	void Start()
	{
		php = GameObject.Find("Player").GetComponent<HealthScript> ();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name =="HPBuff")
		{
			if (php.hp <5)
			{
				php.hp += HPRes;
				Destroy(other.gameObject);
			}
		}
	}


}
