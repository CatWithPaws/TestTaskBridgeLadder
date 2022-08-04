using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IPlayer
{
	public static Player instance;

	public Transform Dot;
	public Vector3 touchInput;
	public bool isDragging;

	

	[SerializeField] private float speed;
	private Rigidbody RBPlayer;
	private Animator playerAnimator;

	Vector3 velocity;


	public int count;

	void Awake()
	{
		RBPlayer = GetComponent<Rigidbody>();
		playerAnimator = GetComponent<Animator>();
		instance = this;
	}

	void FixedUpdate()
	{
		Move();
		RBPlayer.velocity = velocity;
	}

	public void SetInputValue(Vector3 value)
	{
		touchInput = Vector3.Lerp(touchInput, value, 0.1f);
	}

	public override void Move()
	{
		velocity = RBPlayer.velocity;
		if (isDragging)
		{
			Vector3 newVelocity = transform.forward * speed;
			velocity = new Vector3(newVelocity.x, RBPlayer.velocity.y, newVelocity.z);
			Dot.position = transform.position - touchInput;
			Dot.position = new Vector3(Dot.position.x, transform.position.y, Dot.position.z);
			var targetRotation = Quaternion.LookRotation(Dot.transform.position - transform.position);
			RBPlayer.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime));
			playerAnimator.Play("Run");
		}
		else
		{
			velocity = Vector3.zero;
			playerAnimator.Play("Idle");
		}
	}


	public override void PickBridgePart(PickBridgePartTrigger bridgePart)
	{
		StartCoroutine(AddBridgePart(bridgePart));
	}

	IEnumerator AddBridgePart(PickBridgePartTrigger bridgePart)
	{
		bridgePart.gameObject.transform.parent = parent;
		Vector3 toPos = Vector3.zero + new Vector3(0, yDiff, 0) * bridges.Count ;
		while (Vector3.Distance(bridgePart.gameObject.transform.localPosition, toPos) > 0.001f)
		{
			toPos = Vector3.zero + new Vector3(0, yDiff, 0) * bridges.Count ;
			bridgePart.gameObject.transform.localPosition = Vector3.Lerp(bridgePart.transform.localPosition, toPos, 0.2f);
			bridgePart.gameObject.transform.localRotation = Quaternion.Lerp(bridgePart.transform.localRotation, Quaternion.identity, 0.2f);
			yield return new WaitForEndOfFrame();
		}
		bridgePart.gameObject.transform.localPosition = new Vector3(0, yDiff * bridges.Count, 0);
		bridgePart.gameObject.transform.localRotation = Quaternion.identity;
		bridges.Add(bridgePart);
		foreach(var item in bridgePart.gameObject.GetComponent<PickBridgePartTrigger>().trails)
		{
			Destroy(item);
		}
	}

	public void DeleteAnOneBridge()
	{
		GameObject item = bridges[bridges.Count - 1].gameObject;
		Destroy(item);
		bridges.RemoveAt(bridges.Count - 1);
	}
}
