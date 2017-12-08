using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderManager : MonoBehaviour {

	//[SerializeField] - отображение приватных членов в инстпекторе

	[Header("Основные настройки:")]
	[SerializeField] private Rigidbody2D playerRigidbody; // компонент персонажа
	[SerializeField] private Transform playerCenterPoint; // дочерний пустой объект, который размещается по центру персонажа
	[SerializeField] private float playerRaySize = 1f; // луч из центра и до точки касания "земли"
	[Header("Управление персонажем:")]
	[SerializeField] private string verticalAxis = "Vertical";
	[SerializeField] private float speed = 1f;
	public static bool isLadder { get; private set; } // true - если персонаж на лестнице
	public static bool isMove { get; private set; } // true - если персонаж движется, находясь на лестнице
	private static LadderManager _internal;
	private bool isTrigger;
	private Bounds ladderBounds;
	private int layerMask;

	void OnDrawGizmosSelected() //луч до земли
	{
		if(playerCenterPoint == null) return;
		Gizmos.color = Color.green;
		Gizmos.DrawRay(playerCenterPoint.position, Vector3.down * playerRaySize);
	}

	void Awake() // вместо start(), вызовется когда экземпляр скрипта будет загружен
	{
		isMove = false;
		isLadder = false;
		layerMask = 1 << playerRigidbody.gameObject.layer | 1 << 2; //слои
		layerMask = ~layerMask;
		_internal = this;
	}

	public static void SetLadderBounds(Bounds bounds)//для передачи коллайдера из скрипта Ladder
	{
		_internal.SetLadderBounds_internal(bounds);
	}

	public static void ResetStatus() //для использования в Ladder
	{
		_internal.ResetStatus_internal();
	}

	void SetLadderBounds_internal(Bounds bounds)//границы лестницы
	{
		ladderBounds = bounds;
		isTrigger = true;
	}

	void ResetStatus_internal()// персонаж не на лестнице
	{
		isTrigger = false;
		isMove = false;
	}

	bool IsGround() // проверяем нахождение на земле лучом
	{
		RaycastHit2D hit = Physics2D.Raycast(playerCenterPoint.position, Vector3.down, playerRaySize, layerMask);
		if(hit.collider) return true;
		return false;
	}

	void MoveUp() //функция движения вверх по лестнице
	{
		if(playerCenterPoint.position.y > ladderBounds.max.y + (playerRaySize/2))//проверка конца лестницы
		{
			UnLock();
			return;
		}

		if(!isLadder) Lock();
		playerRigidbody.transform.Translate(Vector3.up * speed * Time.deltaTime);//плавное движение вверх
		isMove = true;
	}

	void MoveDown() //функция движения вниз по лестнице
	{
		if(playerCenterPoint.position.y < ladderBounds.center.y && IsGround())//проверка начала лестницы (от земли)
		{
			UnLock();
			return;
		}

		if(!isLadder) Lock();
		playerRigidbody.transform.Translate(Vector3.down * speed * Time.deltaTime);//плавное движение вниз
		isMove = true;
	}

	void Lock() // блокировка на лестнице
	{
		isLadder = true;
		playerRigidbody.velocity = Vector2.zero;
		playerRigidbody.isKinematic = true; //кинематическая физика персонажа
		//персонаж по середине лестницы
		playerRigidbody.transform.position = new Vector3(ladderBounds.center.x, playerRigidbody.transform.position.y, playerRigidbody.transform.position.z);
	}

	void UnLock() // не на лестнице
	{
		isMove = false;
		isLadder = false;
		// переключает физику персонажа из кинематической в динамическую
		playerRigidbody.isKinematic = false;
		playerRigidbody.bodyType = RigidbodyType2D.Dynamic;
	}

	void Update()
	{
		if (!isTrigger) // возможность спрыгнуть в любом месте 
			UnLock ();
		else 
		{
			if (Input.GetAxis (verticalAxis) > 0)
				MoveUp ();
			else if (Input.GetAxis (verticalAxis) < 0)
				MoveDown ();
			else if (Input.GetAxis (verticalAxis) == 0)
				isMove = false;
		}
	}
}