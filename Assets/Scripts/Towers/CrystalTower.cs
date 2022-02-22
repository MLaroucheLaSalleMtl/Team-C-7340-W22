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
		[SerializeField] private LineRenderer lineRenderer = null;
		[SerializeField] private float damage = 5f; //per frame
		[SerializeField] private DamageTypes damageType = DamageTypes.Magical;

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
	}
}


