using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBridgePart : MonoBehaviour
{
    public enum State { Empty,Created};

    public State state;

    Collider collider;
    MeshRenderer meshRenderer;

    void Awake()
	{
        meshRenderer = GetComponent<MeshRenderer>();
	}

    public void CreateBridge (Color targetColor)
	{
        StartCoroutine(ChangeColor(Color.white, targetColor));
        state = State.Created;
	}

    IEnumerator ChangeColor(Color from,Color to)
	{
        meshRenderer.enabled = true;
        Color color = Color.white;
        meshRenderer.material.color = color;
        while (color != to)
		{
            color = Color.Lerp(color,to,0.05f);
            meshRenderer.material.color = color;
            yield return null;
        }

        
	}
}
