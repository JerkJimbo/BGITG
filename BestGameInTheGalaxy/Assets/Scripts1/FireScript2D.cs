using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireScript2D : MonoBehaviour {
    public GameObject TextObject;
    Text textComponent;
    public BulletController BC;
    public bool CheckShot;
	public float speed = 10; // скорость пули
	public Rigidbody2D bullet; // префаб нашей пули
	public Transform gunPoint; // точка рождения
	public float fireRate = 500; // скорострельность

	public Transform zRotate; // объект для вращения по оси Z

	// ограничение вращения
	public float minAngle = -40;
	public float maxAngle = 40;

	private float curTimeout;
    
	
	void Start()
	{
        curTimeout = fireRate + 1;
        textComponent = TextObject.GetComponent<Text>();
        BC = GameObject.Find("Player").GetComponent<BulletController>();
	}

	/*void SetRotation()
	{
		Vector3 mousePosMain = Input.mousePosition;
		mousePosMain.z = Camera.main.transform.position.z; 
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);
		lookPos = lookPos - transform.position;
		float angle  = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		angle = Mathf.Clamp(angle, minAngle, maxAngle);
		zRotate.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}*/
	
	void Update()
	{
        textComponent.text = BC.ammoCount.ToString();
        if (Input.GetMouseButton(0))
		{
			Fire();
		}
		else
		{ 
                curTimeout += 10;
			
		}

		//if(zRotate) SetRotation();
	}

	void Fire()
	{
		curTimeout += 10;
		if(curTimeout > fireRate && BC.ammoCount>0)
		{
            BC.ammoCount--;
            CheckShot = true;
			curTimeout = 0;
			Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
			clone.velocity = transform.TransformDirection(gunPoint.right * speed);
			clone.transform.right = gunPoint.right;
            
		}
	}
}
