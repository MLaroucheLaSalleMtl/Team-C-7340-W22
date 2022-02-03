using UnityEngine;
using UnityEngine.AI;
using TowersNoDragons.EnemyTypes;
using System.Collections;

namespace TowersNoDragons.AI
{
	public abstract class Enemy : MonoBehaviour
	{
		[SerializeField] protected EnemyType enemyType = null;

		protected Transform[] path = null;

		private int currentPathIndex = 0;
		private NavMeshAgent agent = null;

		private void Awake()
		{
			agent = GetComponent<NavMeshAgent>();
		}

		private void Start()
		{
			agent.speed = enemyType.MovementSpeed;
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
					if (agent.remainingDistance <= 0.2f)
					{
						reachedWayPoint = true;
						currentPathIndex++;
					}
				}
				yield return null;
			}
		}
	}
}


