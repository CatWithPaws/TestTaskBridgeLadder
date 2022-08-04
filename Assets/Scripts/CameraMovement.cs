using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 startCameraPos;
	Player playerMovement;
    void Awake()
	{
		startCameraPos = transform.position;
		playerMovement = FindObjectOfType<Player>();
	}

	void Update()
	{
		transform.position = startCameraPos + playerMovement.gameObject.transform.position;
	}

}
