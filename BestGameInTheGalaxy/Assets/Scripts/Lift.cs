using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

	public float SpeedMove = 3f;
	public float VectorMove = 0;
	public float MaxY = 0.5f;
	public float MinY = -2.8f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 Pos = this.transform.position;
		if (Pos.y == MaxY)
			//VectorMove = -1;
		if (Pos.y == MinY) //VectorMove = 1;
		Pos.y = Pos.y + SpeedMove * VectorMove * Time.deltaTime;
		this.transform.position = Pos;
	}
}
