using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowersNoDragons.Towers
{
	public class CrystalTower : Tower
	{
		protected override void AttackTarget()
		{
			print("crystal tower attack");
		}

		protected override void StopAttacking()
		{
			//
		}
	}
}


