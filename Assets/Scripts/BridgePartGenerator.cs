using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePartGenerator : MonoBehaviour
{
	[SerializeField] Transform[] OnFloorBridgeParts;

    void Start()
	{

		foreach(var item in OnFloorBridgeParts)
		{
			GameObject prefabBridgesOnFloor = Resources.Load("Prefabs/OnFloorBridgePart") as GameObject;
			GameObject onFloorBridgePart = Instantiate(prefabBridgesOnFloor, Vector3.zero, Quaternion.identity, item.transform);
			onFloorBridgePart.transform.localPosition = Vector3.zero;
			prefabBridgesOnFloor.GetComponent<PickBridgePartTrigger>().bridgeGenerator = this;
			float percent = Random.Range(0, 100);
			int matIndex;
			if (percent > 75)
			{
				matIndex = 3;
			}
			else if (percent < 75 && percent > 50)
			{
				matIndex = 2;
			}
			else if (percent < 50 && percent > 25)
			{
				matIndex = 1;
			}
			else
			{
				matIndex = 0;
			}
			prefabBridgesOnFloor.GetComponent<PickBridgePartTrigger>().SetColor(matIndex);
		}
		
	}

	public void RecoverBridgePartWithDelay(Transform OnFloorBridgeContainerTransform)
	{
		StartCoroutine(RecoverBridgePart(OnFloorBridgeContainerTransform));
	}

	IEnumerator RecoverBridgePart(Transform OnFloorBridgeContainer)
	{
		yield return new WaitForSeconds(4f);
		CreateBridge(OnFloorBridgeContainer);
	}

	void CreateBridge(Transform OnFloorBridgeContainer)
	{
		GameObject prefabBridgesOnFloor = Resources.Load("Prefabs/OnFloorBridgePart") as GameObject;
		GameObject onFloorBridgePart = Instantiate(prefabBridgesOnFloor, Vector3.zero, Quaternion.identity, OnFloorBridgeContainer.transform);
		onFloorBridgePart.transform.localPosition = Vector3.zero;
		int[] countofColors = new int[GlobalVars.instance.PlayerMaterials.Length];
		foreach(var item in OnFloorBridgeParts)
		{
			Material[] PlayerMaterials = GlobalVars.instance.PlayerMaterials;
			if(item.gameObject.GetComponentInChildren<PickBridgePartTrigger>() == null) { continue; }
			Material bridgeMaterial = item.gameObject.GetComponentInChildren<PickBridgePartTrigger>().material;
			for(int i = 0; i < PlayerMaterials.Length; i++)
			{
				if (bridgeMaterial.color == PlayerMaterials[i].color)
				{
					countofColors[i]++;
					break;
				}
			}
		}

		int minCountIndex = 0;
		for(int i = 1; i < countofColors.Length; i++)
		{
			if(countofColors[i] < countofColors[minCountIndex])
			{
				minCountIndex = i;
			}
		}
		print("0 element: " + countofColors[0] + "\n" + "1 element : " + countofColors[1] + "\n" + "2 element : " + countofColors[2] + "\n" + "3 element : " + countofColors[3]);
		prefabBridgesOnFloor.GetComponent<PickBridgePartTrigger>().SetColor(minCountIndex);
	}
}
