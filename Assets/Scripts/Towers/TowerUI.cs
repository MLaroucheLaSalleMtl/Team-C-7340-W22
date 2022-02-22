using UnityEngine;

namespace TowersNoDragons.UI
{
	public class TowerUI : MonoBehaviour, ISelectable
	{
		[SerializeField] private GameObject SellUpgradePanel = null;

		private bool isPanelShown = false;

		public void Deselect()
		{
			
		}

		public void Select()
		{
			SellUpgradePanel.SetActive(true);
		}
	}
}


