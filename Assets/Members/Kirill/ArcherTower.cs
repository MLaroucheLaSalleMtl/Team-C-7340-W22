using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowersNoDragons.Towers
{
	public class ArcherTower : Tower
	{
		protected override void AttackTarget()
		{
			print($"archer tower Attacks {base.target.name}");
		}
	}
}


