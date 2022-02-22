/*
 * Script that monitors the UI for building new towers
 */
using TowersNoDragons.Towers;
using UnityEngine;

namespace TowersNoDragons.UI
{
	public class BuildHandler : MonoBehaviour,ISelectable
	{
		[SerializeField] private GameObject BuildPanel = null;
		[SerializeField] private Tower archerTower = null;
		[SerializeField] private Tower crystalTower = null;
		//TO ADD: LongRangeTower
		//TO ADD: ScorpionTower

		[SerializeField] private float lowest_Y_Spawn = -10f;

		private bool isBuildPanelShown = false;
		private Vector3 spawnPos;

		private void Start()
		{
			spawnPos = transform.position;
			spawnPos.y = lowest_Y_Spawn;
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

		public void Select()
		{
			if (isBuildPanelShown) { return; }
			isBuildPanelShown = true;
			BuildPanel.SetActive(true);
		}

		public void Deselect()
		{
			if (!isBuildPanelShown) { return; }
			isBuildPanelShown = false; ;
			BuildPanel.SetActive(false);
		}

		//build LongRangeTower
		//build ScorpionTower
	}
}


