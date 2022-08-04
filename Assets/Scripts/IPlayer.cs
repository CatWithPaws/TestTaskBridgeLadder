using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPlayer : MonoBehaviour
{
	public Material material;
	public List<PickBridgePartTrigger> bridges;
	[SerializeField] protected Transform parent;
	[SerializeField] protected SkinnedMeshRenderer meshRenderer;
	protected float yDiff = 0.3f;
	public abstract void Move();
	public abstract void PickBridgePart(PickBridgePartTrigger bridgePart);

	void Start()
	{
		meshRenderer.material = material;
	}

}
