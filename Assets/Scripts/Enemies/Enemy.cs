using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using TowersNoDragons.EnemyTypes;
using TowersNoDragons.AttackTypes;

namespace TowersNoDragons.AI
{
	public abstract class Enemy : MonoBehaviour
	{
		[SerializeField] private EnemyType enemyType = null;

		private Transform[] path = null;

		private int currentPathIndex = 0;
		private NavMeshAgent agent = null;
		private EnemyEventHandler eventHandler;

		//stats
		private float baseArmor;
		private float magicResistance;
		private float hp;

		private void Awake()
		{
			agent = GetComponent<NavMeshAgent>();
			eventHandler = GetComponent<EnemyEventHandler>();
		}

		private void Start()
		{
			IntializeStats();
		}

		public void AssignPath(Transform[] path)
		{
			this.path = path;
			if(this.path == null) { return; }

			StartCoroutine(PathProcess());

		}

		private IEnumerator PathProcess()
		{
			
			bool reachedWayPoint = true;

			while(currentPathIndex < path.Length)
			{
				if(reachedWayPoint)
				{
					agent.SetDestination(this.path[currentPathIndex].position);
					reachedWayPoint = false;
				}
				else
				{
					if (agent.isOnNavMesh && agent.remainingDistance <= 0.2f)
					{
						reachedWayPoint = true;
						currentPathIndex++;
					}
				}
				yield return null;
			}
		}

		private void IntializeStats()
		{
			this.agent.speed = this.enemyType.MovementSpeed;
			this.baseArmor = this.enemyType.BaseArmor;
			this.magicResistance = this.enemyType.MagicResistance;
			this.hp = this.enemyType.Hp;
		}

		public void TakeDamage(float damage, DamageTypes damageType)
		{
			float finalDamage;

			switch(damageType)
			{
				case DamageTypes.Magical:
					finalDamage = damage - (damage * this.magicResistance);
					break;

				case DamageTypes.Physical:
					finalDamage = damage - (damage * this.baseArmor);
					break;

				default:
					finalDamage = 0;
					break;
			}

			this.hp -= finalDamage;

			float percentDamage = this.hp / this.enemyType.Hp;

			eventHandler.OnTakeDamageEvent(amount: this.hp,damagePercent: percentDamage);
		}
	}
}


