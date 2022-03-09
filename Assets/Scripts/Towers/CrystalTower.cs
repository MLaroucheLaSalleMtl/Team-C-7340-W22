/*
 * The Crystal Tower renderes a line from its origin to the target position.
 * Due to the cooldown of shooting for every tower OnUpdate, the cooldown for attacks of the Crystal Tower
 * Should always be set to 0!!!
 */

using TowersNoDragons.AttackTypes;
using UnityEngine;

namespace TowersNoDragons.Towers
{
	public class CrystalTower : Tower
	{
		[Header("Crystal Tower Prefs")]
		[SerializeField] private MeshRenderer crystalTowerMeshRenderer = null;
		[SerializeField] private LineRenderer lineRenderer = null;
		[SerializeField] private float damage = 5f; //per frame
		[SerializeField] private DamageTypes damageType = DamageTypes.Magical;

		[Header("Upgrades")]
		[SerializeField] private Material levelTwoLaserColor = null;
		[SerializeField] private float levelTwoDamage = 0.02f;
		

		protected override void AttackTarget()
		{
			if(base.target == null) { StopAttacking(); }
			lineRenderer.enabled = true;
			lineRenderer.SetPosition(0, lineRenderer.transform.position); //start pos
			lineRenderer.SetPosition(1, base.target.transform.position); //target pos /end pos
			base.target.TakeDamage(damage, damageType);
		}

		protected override void StopAttacking()
		{
			lineRenderer.enabled = false;
		}

		public override void UpgradeTower()
		{
			base.UpgradeTower();

			//Crytal tower implementation
			this.damage += levelTwoDamage;
			lineRenderer.material = levelTwoLaserColor;
			var newMats = crystalTowerMeshRenderer.materials; //Create and assign a new array of materials
			newMats[4] = levelTwoLaserColor;				  //the color of the crystal
			crystalTowerMeshRenderer.materials = newMats;	  //Create and assign a new array of materials


		}
	}
}


