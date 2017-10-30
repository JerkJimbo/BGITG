using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderManager : MonoBehaviour {

	[Header("Основные настройки:")]
	[SerializeField] private Rigidbody2D playerRigidbody; 
	[SerializeField] private Transform playerCenterPoint;
	[SerializeField] private float playerRaySize = 1f; 
	[Header("Управление персонажем:")]
	[SerializeField] private string verticalAxis = "Vertical";
	[SerializeField] private float speed = 1f;
	public static bool isLadder { get; private set; } 
	public static bool isMove { get; private set; } 
	private static LadderManager _internal;
	private bool isTrigger;
	private Bounds ladderBounds;
	private int layerMask;

	void OnDrawGizmosSelected()
	{
		if(playerCenterPoint == null) return;
		Gizmos.color = Color.green;
		Gizmos.DrawRay(playerCenterPoint.position, Vector3.down * playerRaySize);
	}

	void Awake()
	{
		isMove = false;
		isLadder = false;
		layerMask = 1 << playerRigidbody.gameObject.layer | 1 << 2;
		layerMask = ~layerMask;
		_internal = this;
	}

	public static void SetLadderBounds(Bounds bounds)
	{
		_internal.SetLadderBounds_internal(bounds);
	}

	public static void ResetStatus()
	{
		_internal.ResetStatus_internal();
	}

	void SetLadderBounds_internal(Bounds bounds)
	{
		ladderBounds = bounds;
		isTrigger = true;
	}

	void ResetStatus_internal()
	{
		isTrigger = false;
		isMove = false;
	}

	bool IsGround()
	{
		RaycastHit2D hit = Physics2D.Raycast(playerCenterPoint.position, Vector3.down, playerRaySize, layerMask);
		if(hit.collider) return true;
		return false;
	}

	void MoveUp()
	{
		if(playerCenterPoint.position.y > ladderBounds.max.y + (playerRaySize/2))
		{
			UnLock();
			return;
		}

		if(!isLadder) Lock();
		playerRigidbody.transform.Translate(Vector3.up * speed * Time.deltaTime);
		isMove = true;
	}

	void MoveDown()
	{
		if(playerCenterPoint.position.y < ladderBounds.center.y && IsGround())
		{
			UnLock();
			return;
		}

		if(!isLadder) Lock();
		playerRigidbody.transform.Translate(Vector3.down * speed * Time.deltaTime);
		isMove = true;
	}

	void Lock()
	{
		isLadder = true;
		playerRigidbody.velocity = Vector2.zero;
		playerRigidbody.isKinematic = true;
		playerRigidbody.transform.position = new Vector3(ladderBounds.center.x, playerRigidbody.transform.position.y, playerRigidbody.transform.position.z);
	}

	void UnLock()
	{
		isMove = false;
		isLadder = false;
		playerRigidbody.isKinematic = false;
		//playerRigidbody.bodyType = RigidbodyType2D.Dynamic;
	}

	void Update()
	{
		Check ();
		if(!isTrigger) return;


		if(Input.GetAxis(verticalAxis) > 0) MoveUp();
		else if(Input.GetAxis(verticalAxis) < 0) MoveDown();
		else if(Input.GetAxis(verticalAxis) == 0) isMove = false;

	}

	void Check()
	{
		if (!isTrigger)
			playerRigidbody.bodyType = RigidbodyType2D.Dynamic;
		else
			playerRigidbody.bodyType = RigidbodyType2D.Kinematic;
	}
}