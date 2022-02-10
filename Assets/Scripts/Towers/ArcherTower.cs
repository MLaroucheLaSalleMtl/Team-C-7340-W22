using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowersNoDragons.Towers
{
	public class ArcherTower : Tower
	{
		[SerializeField] Archer archer = null; //TODO: think about changing it to an array for upgrades and more archers


		protected override void AttackTarget()
		{
			//tell archer to rotate towards the target and assign a target
			archer.Attack(target);
		}

		protected override void StopAttacking()
		{
			archer.StopAttacking();
		}
	}
}

