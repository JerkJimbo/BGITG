// NULLcode Studio © 2015
// null-code.ru

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet2D : MonoBehaviour {

    public int damage = 1;
    public bool isEnemyShot = false;

	void Start()
	{
		// уничтожить объект по истечению указанного времени (секунд), если пуля никуда не попала
		Destroy(gameObject, 20);
	}
}
