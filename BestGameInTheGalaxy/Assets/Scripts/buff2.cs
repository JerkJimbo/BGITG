using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff2 : MonoBehaviour {

	//усиление прыжка на несколько секунд

	public Move m;
	public float NewForce; //знаечение усиления, изменяется в инспекторе
	private float SaveJumpForce;//для сохранения изначальной силы
	public int ForceTime; //длительность усиления, изменяется в инспекторе

	void Start()
	{
		//подключаем скрипт движения
		m = GameObject.Find ("Player").GetComponent<Move> ();
		SaveJumpForce = m.jumpForce;//сохраняем изначальную
	}

	IEnumerator Inst()
	{
		yield return new WaitForSeconds (ForceTime);//продолжительность баффа
		m.jumpForce = SaveJumpForce;//возвращаем изначальную силу
	}

	//поднятие баффа
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "buff2") 
		{
			m.jumpForce = NewForce;
			Destroy (other.gameObject);//уничтожаем объект
			StartCoroutine (Inst());

		}
	}
}
