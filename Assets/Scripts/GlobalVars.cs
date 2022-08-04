using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
	public static GlobalVars instance;

	public Material[] PlayerMaterials;

	void Awake()
	{
		instance = this;
	}
}
