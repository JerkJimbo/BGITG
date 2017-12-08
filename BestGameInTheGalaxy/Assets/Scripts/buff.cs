using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buff : MonoBehaviour {

	//ускорение персонажа на несколько секунд

	public Move m;
	public float Acceleration; //знаечение ускорения, изменяется в инспекторе
	private float SaveSpeed;//для сохранения изначальной скорости
	public int AccTime; //длительность ускорения, изменяется в инспекторе

	void Start()
	{
		//подключаем скрипт движения
		m = GameObject.Find ("Player").GetComponent<Move> ();
		SaveSpeed = m.speed;//сохраняем изначальную
	}

	IEnumerator Inst()
	{
		yield return new WaitForSeconds (AccTime);//продолжительность баффа
		m.speed = SaveSpeed;//возвращаем изначальную скорость
	}

	//поднятие баффа
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "buff") 
		{
			m.speed = Acceleration;
			Destroy (other.gameObject);//уничтожаем объект
			StartCoroutine (Inst());

		}
	}
}
