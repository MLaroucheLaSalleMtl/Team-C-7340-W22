using TowersNoDragons.AttackTypes;
using UnityEngine;

namespace TowersNoDragons.Towers
{
	public class CrystalTower : Tower
	{
		[SerializeField] private LineRenderer lineRenderer = null;
		[SerializeField] private float damage = 5f; //per frama
		[SerializeField] private DamageTypes damageType = DamageTypes.Magical;

		private void Start()
		{
			lineRenderer.SetPosition(0, lineRenderer.transform.position);
		}

		protected override void AttackTarget()
		{
			if(base.target == null) { StopAttacking(); }
			lineRenderer.enabled = true;
			lineRenderer.SetPosition(1, base.target.transform.position);
			base.target.TakeDamage(damage, damageType);
		}

		protected override void StopAttacking()
		{
			lineRenderer.enabled = false;
		}
	}
}


