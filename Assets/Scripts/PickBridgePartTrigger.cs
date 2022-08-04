using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBridgePartTrigger : MonoBehaviour
{
	public Material material;
	public BridgePartGenerator bridgeGenerator;
	public TrailRenderer[] trails;
	public void SetColor(int colorIndex)
	{
		
		Material rndMat = GlobalVars.instance.PlayerMaterials[colorIndex];
		GetComponent<MeshRenderer>().material = rndMat;
		material = rndMat;
		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (material.color == other.GetComponent<IPlayer>().material.color)
			{bridgeGenerator.RecoverBridgePartWithDelay(transform.parent);
				other.GetComponent<IPlayer>().PickBridgePart(GetComponent<PickBridgePartTrigger>());
				
			}
		}
	}
}
