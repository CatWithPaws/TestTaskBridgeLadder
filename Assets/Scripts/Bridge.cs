using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] InBridgePart[] bridgePieces;
	// [SerializeField] GameObject Collider;


    public void CreateBridge(Color color)
	{
        for(int i = 0; i < bridgePieces.Length; i++)
		{
			if (bridgePieces[i].state == InBridgePart.State.Empty)
			{
				if(Player.instance.bridges.Count > 0)
				{
					bridgePieces[i].CreateBridge(color);
					Player.instance.DeleteAnOneBridge();
				}
				break;
			}
		}
	}

}
