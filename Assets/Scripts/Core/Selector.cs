using UnityEngine;
using TowersNoDragons.Input;
using TowersNoDragons.UI;

namespace TowersNoDragons.Core
{
    public class Selector : MonoBehaviour
    {
        [SerializeField] private GameObject selectedGameObject = null;
        [SerializeField] private LayerMask layerMask = new LayerMask();

        private Ray ray;
        private RaycastHit hit;
        private bool hitGround = false;


		private void Update()
		{
            //if the mouse points at the ground and is clicked
            if (InputController.Instance.MouseClick() && hitGround)
            {
                if(selectedGameObject != null)
				{
                    selectedGameObject.GetComponent<ISelectable>().Deselect();
                }

                selectedGameObject = null;
            }
        

        }

		private void FixedUpdate()
        {
            ray = Camera.main.ScreenPointToRay(InputController.Instance.GetMousePosition());
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                //if the mouse points at the ground
                if (hit.collider.CompareTag("Ground"))
                {
                    hitGround = true;
                    return;
                }

                else if(selectedGameObject == hit.collider.gameObject) { return; }

                else if (selectedGameObject!= null)
				{
                    selectedGameObject.GetComponent<ISelectable>().Deselect();
                    selectedGameObject = hit.collider.gameObject;
                    selectedGameObject.GetComponent<ISelectable>().Select();
                }

				else
				{
                    selectedGameObject = hit.collider.gameObject;
                    selectedGameObject.GetComponent<ISelectable>().Select();
                }

                //if the mouse points at any Selectable object
                hitGround = false;
               
            }
        }
	}
}


