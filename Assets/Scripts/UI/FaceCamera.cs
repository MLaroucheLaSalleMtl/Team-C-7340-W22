using UnityEngine;
using TowersNoDragons.Cameras;

namespace TowersNoDragons.UI
{
	public class FaceCamera : MonoBehaviour
	{
		//TODO: show ui onlu when attacked
		[SerializeField] Canvas canvas = null;
		[SerializeField] private float maxRectWidth = 4f;
		[SerializeField] private float minRectWidth = 1.5f;
		[SerializeField] private float maxRectHeight = 1.2f;
		[SerializeField] private float minRectHeight = 0.9f;

		private Vector2 rectStats = Vector2.zero;

		CameraController cameraController;
		RectTransform rectTransform;

		private void Awake()
		{
			cameraController = FindObjectOfType<CameraController>();
			rectTransform = GetComponent<RectTransform>();
		}

		private void LateUpdate()
		{
			DynamiclyScaleHPbar();

			transform.LookAt(
				transform.position + Camera.main.transform.rotation * Vector3.forward,
				Camera.main.transform.rotation * Vector3.up
				);
		}

		private void DynamiclyScaleHPbar()
		{
			rectStats.x = cameraController.ZoomRatio * (maxRectWidth - minRectWidth) + minRectWidth;
			rectStats.y = cameraController.ZoomRatio * (maxRectHeight - minRectHeight) + minRectHeight;

			rectTransform.sizeDelta = rectStats;
		}
	}

	 
}


