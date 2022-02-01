using TowersNoDragons.AI;
using TowersNoDragons.TowerTypes;
using UnityEngine;

namespace TowersNoDragons.Towers
{
	public abstract class Tower : MonoBehaviour
	{
		[SerializeField] protected TowerType towerType = null;
		[SerializeField] protected Enemy target = null; //TODO: remove serialized || for testing only
		[SerializeField] private LayerMask enemyLayer = new LayerMask();

		//testing params / remove later
		[SerializeField] private float searchRadiusOffset = 1f;

		//params
		private readonly int numberOfcollidersSearch = 1; //size of the search colliders array
		private Collider[] enemyCollided;


		private void Start()
		{
			enemyCollided = new Collider[numberOfcollidersSearch];
		}

		private void FixedUpdate()
		{
			if (target == null)
			{
				SearchForEnemy();
			}

			if (target != null)
			{
				if(IsInRange())
				{
					AttackTarget(); //Consider attacking in the Update func
				}
			}
		}

		private void SearchForEnemy()
		{
			int collided = Physics.OverlapSphereNonAlloc(transform.position, towerType.GetTowerRange(), this.enemyCollided, enemyLayer);
			if (collided != 0)
			{
				target = enemyCollided[0].GetComponentInParent<Enemy>(); //consider using a collider on the root enemy
			}
		}

		private bool IsInRange()
		{
			if (Vector3.Distance(transform.position, target.transform.position) > towerType.GetTowerRange() + searchRadiusOffset)
			{
				target = null;
				enemyCollided[0] = null;
				return false;
			}

			return true;
		}

		protected abstract void AttackTarget();


		//Testing tool to visualize range in the editor
		private void OnDrawGizmos()
		{
			Gizmos.DrawWireSphere(transform.position, towerType.GetTowerRange());
		}
	}
}


