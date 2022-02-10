using UnityEngine;
using UnityEngine.InputSystem;

public class TestMouseOver : MonoBehaviour
{
	[SerializeField] private LayerMask layerMask = new LayerMask();

	private GameObject selectedGameObject = null;

	private void FixedUpdate()
	{
		Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
		if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity,layerMask))
		{
			if(selectedGameObject == hit.collider.gameObject) { return; }
			print("found new");
			selectedGameObject = hit.collider.gameObject;
		}
		else
		{
			selectedGameObject = null;
		}
	}
}
