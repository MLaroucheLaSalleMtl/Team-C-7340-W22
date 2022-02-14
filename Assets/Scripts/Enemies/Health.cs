using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowersNoDragons.AI
{
	public class Health : MonoBehaviour
	{
		private EnemyEventHandler eventHandler;

		private void Awake()
		{
			eventHandler = GetComponent<EnemyEventHandler>();
		}


		public void UpdateHealth(float newHealth, float percentDamage)
		{
			eventHandler.OnUI_HP_Update(percentDamage);

			if (newHealth <= 0)
			{
				eventHandler.OnDeathEvent();
				Destroy(gameObject); //TODO: MAKE A DEATH ANIMATION /RAGDOLL
			}

		}


	}
}

