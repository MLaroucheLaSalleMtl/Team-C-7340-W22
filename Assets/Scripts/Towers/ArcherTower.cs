/*
 * The arher tower is just a stand for the actual archer.
 */

using UnityEngine;

namespace TowersNoDragons.Towers
{
	public class ArcherTower : Tower
	{
		[SerializeField] Archer archer = null;


		protected override void AttackTarget()
		{
			//tell archer to rotate towards the target and assign a target
			archer.Attack(target);
		}

		protected override void StopAttacking()
		{
			archer.StopAttacking();
		}

		public override void UpgradeTower()
		{
			base.UpgradeTower();
			//upgrade dmg
			//upgrade range
			//upgrade fire rate
			//add another archer?
		}
	}
}

