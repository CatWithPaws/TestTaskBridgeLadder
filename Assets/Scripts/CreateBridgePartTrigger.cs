using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBridgePartTrigger : MonoBehaviour
{
    [SerializeField] Bridge bridge;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Player.instance.bridges.Count > 0)
            {
                bridge.CreateBridge(other.gameObject.GetComponent<IPlayer>().material.color);
                Destroy(gameObject);
            }
        }
       
    }
}
