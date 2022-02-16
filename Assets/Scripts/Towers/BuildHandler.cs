using TowersNoDragons.Towers;
using UnityEngine;

namespace TowersNoDragons.UI
{
	public class BuildHandler : MonoBehaviour
	{
		[SerializeField] private GameObject BuildPanel = null;
		[SerializeField] private Tower archerTower = null;
		[SerializeField] private Tower crystalTower = null;
		[SerializeField] private float lowest_Y_Spawn = -10f;

		private bool isBuildPanelShown = false;
		private Vector3 spawnPos;

		private void Start()
		{
			spawnPos = transform.position;
			spawnPos.y = lowest_Y_Spawn;
		}

		public void DisplayBuildPanel()
		{
			isBuildPanelShown = !isBuildPanelShown;
			BuildPanel.SetActive(isBuildPanelShown);
		}

		public void BuildArcherTower()
		{
			
			var instance = Instantiate(archerTower, spawnPos, Quaternion.identity);
			instance.GetComponent<Tower>().AssignBuildingPlace(this);
			gameObject.SetActive(false);
		}

		public void BuildCrystalTower()
		{
			var instance = Instantiate(crystalTower, spawnPos, Quaternion.identity);
			instance.GetComponent<Tower>().AssignBuildingPlace(this);
			gameObject.SetActive(false);
		}
	}
}


