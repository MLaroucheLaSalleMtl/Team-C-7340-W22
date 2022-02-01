using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CameraController
namespace TowersNoDragons.Camera
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField] private float cameraMoveSpeed = 10f;

		//TODO: ADD CAMERA BOUNDS!
		//TODO: NEW INPUT SYSTEM
		//TODO: ADJUST SCALE
		//TODO: ADD ZOOM
		[SerializeField] private float max_X = 500f;
		[SerializeField] private float min_X = -500f;
		[SerializeField] private float max_Z = 500f;
		[SerializeField] private float min_Z = 100f;

		private float horizontal, vertical;

		private Vector3 direction_x = new Vector3();
		private Vector3 direction_y = new Vector3();
		private Vector3 newPosition = new Vector3();



		private void Update()
		{
			//horizontal = Input.GetAxisRaw("Horizontal");
			//vertical = Input.GetAxisRaw("Vertical");

			direction_x = horizontal * transform.right * cameraMoveSpeed * Time.deltaTime;
			direction_y = vertical * transform.forward * cameraMoveSpeed * Time.deltaTime;

			newPosition = direction_x + direction_y + transform.position;

			newPosition.x = Mathf.Clamp(newPosition.x, min_X, max_X);
			newPosition.z = Mathf.Clamp(newPosition.z, min_Z, max_Z);
		}

		private void LateUpdate()
		{
			transform.position = newPosition;
		}
	}
}

