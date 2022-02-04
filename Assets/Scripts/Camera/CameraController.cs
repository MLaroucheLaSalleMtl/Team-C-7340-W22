using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowersNoDragons.Input;

//CameraController
namespace TowersNoDragons.Camera
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField] private float cameraMoveSpeed = 10f;
		[SerializeField] private float scrollSpeed = 10f;
		[SerializeField] private Transform cameraTransform = null;

		//TODO: ADD CAMERA BOUNDS!
		//TODO: ADD ZOOM
		[Header("Movement Bounds")]
		[SerializeField] private float max_X = 500f;
		[SerializeField] private float min_X = -500f;
		[SerializeField] private float max_Z = 500f;
		[SerializeField] private float min_Z = 100f;

		[Header("Scroll Bounds")]
		[SerializeField] private float maxScrollDown = 100f;
		[SerializeField] private float maxScrollUp = 500f;

		private InputController InputController;
		private float horizontal, vertical, scrollValue;

		//Camera Rig
		private Vector3 direction_x = new Vector3();
		private Vector3 direction_y = new Vector3();
		private Vector3 newPosition = new Vector3();

		//Main Camera
		private Vector3 newScrollPos = new Vector3();

		private void Awake()
		{
			InputController = InputController.Instance;
			newScrollPos = cameraTransform.localPosition;
		}


		private void Update()
		{
			//Movement - Camera Rig
			horizontal = InputController.GetHorizontalDirection();
			vertical = InputController.GetVerticalDirection();

			direction_x = horizontal * transform.right * cameraMoveSpeed * Time.deltaTime;
			direction_y = vertical * transform.forward * cameraMoveSpeed * Time.deltaTime;

			newPosition = direction_x + direction_y + transform.position;

			//newPosition.x = Mathf.Clamp(newPosition.x, min_X, max_X);
			//newPosition.z = Mathf.Clamp(newPosition.z, min_Z, max_Z);

			//Scroll - Main Camera
			newScrollPos.y += scrollSpeed * Time.deltaTime * InputController.GetScrollDirection();

			newScrollPos.y = Mathf.Clamp(newScrollPos.y, maxScrollDown, maxScrollUp);

			newScrollPos.z = newScrollPos.y * -1;




		}

		private void LateUpdate()
		{
			transform.position = newPosition;
			cameraTransform.localPosition = newScrollPos;
		}
	}
}

