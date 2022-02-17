using TowersNoDragons.AttackTypes;
using TowersNoDragons.Projectiles;
using UnityEngine;

namespace TowersNoDragons.Towers
{
	public class LongRangeTower : Tower
	{
		
		[SerializeField] private FireBall projectilePrefab;
		
		protected override void AttackTarget()
		{

			if (base.target == null) { StopAttacking(); return; }

			var instance = Instantiate(projectilePrefab,transform.position,Quaternion.identity);
			instance.SetTargetPosition(base.target.transform.position);
			
		}

		protected override void StopAttacking()
		{
			target = null;
		}
	}
}


