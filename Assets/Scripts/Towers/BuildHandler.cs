/*
 * Script that monitors the UI for building new towers
 */
using TowersNoDragons.Towers;
using UnityEngine;
using System;
using TowersNoDragons.Economy;

namespace TowersNoDragons.UI
{
	public class BuildHandler : MonoBehaviour,ISelectable
	{

		[SerializeField] private GameObject BuildPanel = null;
		[SerializeField] private GameObject selectionCircleSprite = null;
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
            if (archerTower.GetTowerPrice() <= EconomyHandler.Instance.GetCurrentGold())
            {
				var instance = Instantiate(archerTower, spawnPos, Quaternion.identity);
				instance.GetComponent<Tower>().AssignBuildingPlace(this);
				gameObject.SetActive(false);
				EconomyHandler.Instance.SubtractGold(archerTower.GetTowerPrice());
			}
		}

		public void BuildCrystalTower()
		{
			if(crystalTower.GetTowerPrice() <= EconomyHandler.Instance.GetCurrentGold())
            {
				var instance = Instantiate(crystalTower, spawnPos, Quaternion.identity);
				instance.GetComponent<Tower>().AssignBuildingPlace(this);
				gameObject.SetActive(false);
				EconomyHandler.Instance.SubtractGold(crystalTower.GetTowerPrice());
			}
			
		}

		public void Select()
		{
			if (isBuildPanelShown) { return; }
			isBuildPanelShown = true;
			BuildPanel.SetActive(true);
			selectionCircleSprite.SetActive(true);
		}

		public void Deselect()
		{
			if (!isBuildPanelShown) { return; }
			isBuildPanelShown = false; ;
			BuildPanel.SetActive(false);
			selectionCircleSprite.SetActive(false);
		}

		//build LongRangeTower
		//build ScorpionTower
	}
}


