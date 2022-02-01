using UnityEngine;
using UnityEngine.AI;
using TowersNoDragons.EnemyTypes;

namespace TowersNoDragons.AI
{
	public abstract class Enemy : MonoBehaviour
	{
		[SerializeField] protected EnemyType enemyType = null;

		private NavMeshAgent agent = null;

		private void Awake()
		{
			agent = GetComponent<NavMeshAgent>();
		}

		private void Start()
		{
			agent.speed = enemyType.MovementSpeed;
		}
	}
}


