using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBuff : MonoBehaviour {


	// Аптечка

	public int HPRes;//кол-во восстанавливаемого здоровья, изменяется в инспекторе
	public HealthScript php; //переменная скрипта здоровья

	void Start()
	{
		// подключаем скрипт здоровья
		php = GameObject.Find("Player").GetComponent<HealthScript> ();
	}

	//поднятие аптечки
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name =="HPBuff")
		{
			if (php.hp <5) //ограничение здоровья
			{
				php.hp += HPRes;
				Destroy(other.gameObject);//уничтожение аптечки после поднтия
			}
		}
	}




}
