/*
 * Center script for all of the events that will be triggered by the enemy's state
 */


using UnityEngine;
using UnityEngine.Events;
using TowersNoDragons.Core;

namespace TowersNoDragons.AI
{
	public class EnemyEventHandler : MonoBehaviour
	{
		[SerializeField] private EnemyEvent OnTakeDamage = null;
		[SerializeField] private EnemyUiEvent OnUiUpdate = null;
		[SerializeField] private UnityEvent OnDeath = null;

		#region UnityEvents_Classes_Definition

		[System.Serializable]
		public class EnemyEvent : UnityEvent<float,float>
		{
		}

		[System.Serializable]
		public class EnemyUiEvent : UnityEvent<float>
		{
		}
		#endregion

		public void OnTakeDamageEvent(float amount, float damagePercent)
		{
			OnTakeDamage.Invoke(amount, damagePercent);
		}


		public void OnDeathEvent()
		{
			OnDeath.Invoke(); //notify the visual indicator and animation about the death of the enemy
			WinLossHandler.Instance.OnTowerKill(); //notify the manager
		}
		

		public void OnUI_HP_Update(float amount)
		{
			OnUiUpdate.Invoke(amount);
		}
	}
}


