using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PanelJoystick : MonoBehaviour, IDragHandler, IBeginDragHandler,IEndDragHandler
{
	Vector3 prevMousePos;
	Vector3 prefDifference;
	Vector3 currentMousePos;

	Player playerMovement;

	void Awake()
	{
		playerMovement = FindObjectOfType<Player>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		prevMousePos = Input.mousePosition.normalized;
		prefDifference = prevMousePos;
		playerMovement.isDragging = true;
	}

	public void OnDrag(PointerEventData eventData)
	{
		currentMousePos = Input.mousePosition;
		
		Vector3 difference = ((prevMousePos - currentMousePos) * 1000).normalized * 3;
		difference.z = difference.y;
		difference.y = 0;
		if(difference != Vector3.zero)
		{
			playerMovement.SetInputValue(difference);
		}
		prevMousePos = currentMousePos;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		playerMovement.isDragging = false;
	}

	
}
