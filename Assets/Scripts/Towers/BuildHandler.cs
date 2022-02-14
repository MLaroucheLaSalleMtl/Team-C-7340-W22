using UnityEngine;

namespace TowersNoDragons.UI
{
	public class BuildHandler : MonoBehaviour
	{
		[SerializeField] private GameObject BuildPanel = null;

		private bool isBuildPanelShown = false;

		public void DisplayBuildPanel()
		{
			isBuildPanelShown = !isBuildPanelShown;
			BuildPanel.SetActive(isBuildPanelShown);
		}

		public void BuildArcherTower()
		{
			print("archer built");
		}
	}
}


