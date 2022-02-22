using System.Collections;
using TowersNoDragons.AttackTypes;
using UnityEngine;

namespace TowersNoDragons.Towers
{
	public class ScorpionTower : Tower
	{
		[SerializeField] private GameObject Hook = null;
		[SerializeField] LineRenderer lineRenderer = null;
		[SerializeField] private float hookSpeed = 5f;
		[SerializeField] private float pullSpeed = 5f;
		[SerializeField] private float damage = 9999f; //insta kill
		[SerializeField] private DamageTypes damageType = DamageTypes.Physical;

		
		private bool isPullProcess = false;
		private bool isHookProcess = false;

		protected override void AttackTarget()
		{
			if (base.target == null) { StopAttacking(); return; }
			if(isPullProcess || isHookProcess) {return; }

			StartCoroutine(ProcessHook());
			
		}

		protected override void StopAttacking()
		{
			base.target = null;
			isPullProcess = false;
			isHookProcess = false;
		}

		private IEnumerator ProcessHook()
		{
			lineRenderer.SetPosition(1, lineRenderer.transform.position);

			//HOOK
			while (target != null && Vector3.Distance(lineRenderer.GetPosition(1),target.transform.position) > 1f)
			{
				isHookProcess = true;
				lineRenderer.SetPosition(0, lineRenderer.transform.position);
				Vector3 newPos = Vector3.Lerp(lineRenderer.GetPosition(1), base.target.transform.position, Time.deltaTime * hookSpeed);
				lineRenderer.SetPosition(1, newPos);
				yield return null;
			}

			isHookProcess = false;

			//PULL
			while (target != null && Vector3.Distance(lineRenderer.GetPosition(0), target.transform.position) > 0.05f)
			{
				if (!isPullProcess)
				{
					base.target.GetHookedAndPulled();
				}
				
				isPullProcess = true;
				base.target.transform.position = Vector3.Lerp(target.transform.position, lineRenderer.GetPosition(0), Time.deltaTime * pullSpeed);
				lineRenderer.SetPosition(1, base.target.transform.position);
				yield return null;
			}

			if(target != null)
			{
				//pull over
				base.target.TakeDamage(damage, damageType);
				
			}

			isPullProcess = false;


		}
	}
}


