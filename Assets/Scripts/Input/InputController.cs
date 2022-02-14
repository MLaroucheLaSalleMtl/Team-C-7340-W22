using UnityEngine;
using UnityEngine.InputSystem;

namespace TowersNoDragons.Input
{
	public class InputController : MonoBehaviour
	{
		public static InputController Instance { get; private set; } = null;

		private enum ScrollDirection
		{
			Scroll_Up,
			Scroll_Down,
			No_Scroll
		}

		private Vector2 movementDirection = new Vector2();
		private ScrollDirection scroll = ScrollDirection.No_Scroll;



		//TODO:consider adding the input to the "persistent object"
		private void Awake()
		{
			Instance = this;
		}

		public float GetHorizontalDirection()
		{
			return movementDirection.x;
		}

		public float GetVerticalDirection()
		{
			return movementDirection.y;
		}

		public int GetScrollDirection()
		{
			switch(scroll)
			{
				case ScrollDirection.No_Scroll:
					return 0;
				case ScrollDirection.Scroll_Down:
					return -1;
				case ScrollDirection.Scroll_Up:
					return 1;

				default:
					return 0;
			}
		}


		#region Inputs_Region

		//Camera Movement
		public void OnMove(InputAction.CallbackContext ctx)
		{
			if(ctx.performed)
			{
				movementDirection = ctx.ReadValue<Vector2>();
			}
			else
			{
				movementDirection = Vector2.zero;
			}
		}

		//Camera Zoom
		public void OnZoom(InputAction.CallbackContext ctx)
		{
			if(ctx.performed)
			{
				if(ctx.ReadValue<float>() > 0) { scroll = ScrollDirection.Scroll_Down; }
				else if(ctx.ReadValue<float>() < 0){ scroll = ScrollDirection.Scroll_Up; }
			}

			else
			{
				scroll = ScrollDirection.No_Scroll;
			}
			
		}

		#endregion

		//Mouse Position 
		public Vector2 GetMousePosition()
        {
			return Mouse.current.position.ReadValue();
		}
		
		//Mouse Click
		public bool MouseClick()
		{
			return Mouse.current.leftButton.wasReleasedThisFrame;
		}
	}
}


