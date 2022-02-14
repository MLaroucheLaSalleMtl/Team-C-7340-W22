using UnityEngine;
using TowersNoDragons.Input;

namespace TowersNoDragons.Core
{
    public class Highlighter : MonoBehaviour
    {
		[SerializeField] private LayerMask layerMask = new LayerMask();
		[SerializeField] private GameObject selectedGameObject = null;
		private Color noEmissionColor;
		private Color highlightedColor = new Color(0, 78, 0);

		private void FixedUpdate()
		{
			Ray ray = Camera.main.ScreenPointToRay(InputController.Instance.GetMousePosition());
			if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
			{
				if (selectedGameObject == hit.collider.gameObject) { return; }
				selectedGameObject = hit.collider.gameObject;

				selectedGameObject.GetComponent<Renderer>().material.EnableKeyword("_EmissionColor");
				selectedGameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", highlightedColor * 3);
			}
			//else
			//{
			//	selectedGameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", noEmissionColor);
			//	selectedGameObject = null;
			//}
		}
	}
}


