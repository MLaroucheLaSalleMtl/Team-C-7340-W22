using UnityEngine;

namespace TowersNoDragons.AI
{
	public class Health : MonoBehaviour
	{
		private EnemyEventHandler eventHandler;

		private bool isDead = false;

		private void Awake()
		{
			eventHandler = GetComponent<EnemyEventHandler>();
		}


		public void UpdateHealth(float newHealth, float percentDamage)
		{
			eventHandler.OnUI_HP_Update(percentDamage);

			if (newHealth <= 0 && !isDead)
			{
				isDead = true;
				eventHandler.OnDeathEvent();
				Destroy(gameObject); //TODO: MAKE A DEATH ANIMATION /RAGDOLL
			}

		}


	}
}

