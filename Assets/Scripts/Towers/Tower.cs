using System.Collections;
using TowersNoDragons.AI;
using TowersNoDragons.TowerTypes;
using TowersNoDragons.UI;
using UnityEngine;

namespace TowersNoDragons.Towers
{
	public abstract class Tower : MonoBehaviour
	{
		[Header("Tower Prefs")]
		[SerializeField] protected TowerType towerType = null; //The base-stats of the tower
		[SerializeField] private LayerMask enemyLayer = new LayerMask(); //layers to collide with
		[SerializeField] private float searchRadiusOffset = 1f; //offset collision to compensate enemy radius of collision
		[Header("Spawning")]
		[SerializeField] float spawningHeight_Y = 4.8f; //based on the tower height, determine the required height to be placed above ground
		[SerializeField] private float spawningSpeed = 1f; //TODO: make CONST/readonly
														   //params
		[SerializeField] private Collider[] enemyCollided;

		//Attacking variables
		protected Enemy target = null;
		private bool isAttacking = false;
		private float attackTimer = 0f;
		[SerializeField] private bool canAttack = false; //TODO: REMOVE SERIALIZE
		private BuildHandler buildingBase = null; //the reference to the base that built this tower | when we sell the tower it should "show" again

		private void Start()
		{
			enemyCollided = new Collider[10];
			StartCoroutine(PositionTower());
		}

		private void Update()
		{
			if (!canAttack) { return; } //not fully spawned yet
			if (target == null)
			{
				attackTimer = 0f;
				isAttacking = false;
				this.StopAttacking();
				return;
			}

			ProcessAttack();

		}

		private void ProcessAttack()
		{
			if (isAttacking && attackTimer == 0)
			{
				AttackTarget();
			}

			attackTimer += Time.deltaTime;

			if (attackTimer >= towerType.GetAttackDelay())
			{
				attackTimer = 0f;
			}
		}

		private void FixedUpdate()
		{
			if (!canAttack) { return; } //not fully spawned yet
			if (target == null)
			{
				SearchForEnemy();	
			}

			else if (target != null)
			{
				if(IsInRange())
				{
					isAttacking = true;
				}
			}
		}

		//Shpere search for a compatable collider of type "Enemy"
		private void SearchForEnemy()
		{
			ClearEnemiesArray();
			int collided = Physics.OverlapSphereNonAlloc(transform.position, towerType.GetTowerRange(), this.enemyCollided, enemyLayer);
			if (collided != 0)
			{
				target = ChooseClosestEnemy();
			}
		}

		//Checks if the target is still in range
		private bool IsInRange()
		{
			if (Vector3.Distance(transform.position, target.transform.position) > towerType.GetTowerRange() + searchRadiusOffset)
			{
				target = null;
				ClearEnemiesArray();
				isAttacking = false;
				this.StopAttacking();
				return false;
			}

			return true;
		}

		private Enemy ChooseClosestEnemy()
		{
			Enemy enemyToReturn = null;
			float minimumDistance = float.MaxValue;

			foreach(var ele in enemyCollided)
			{
				if(ele == null) { continue; }
				if(Vector3.Distance(transform.position, ele.transform.position) < minimumDistance)
				{
					enemyToReturn = ele.GetComponent<Enemy>();
					minimumDistance = Vector3.Distance(transform.position, ele.transform.position);
				}
			}

			return enemyToReturn;
		}

		private void ClearEnemiesArray()
		{
			for (int i = 0; i < enemyCollided.Length; i++)
			{
				enemyCollided[i] = null;
			}
		}

		private IEnumerator PositionTower()
		{
			while (transform.position.y < spawningHeight_Y)
			{
				transform.Translate(Vector3.up * spawningSpeed * Time.deltaTime);
				yield return null;
			}

			canAttack = true; //fully spawned
		}

		public void AssignBuildingPlace(BuildHandler buildHandler)
		{
			buildingBase = buildHandler;
		}
		
		/// <summary>
		/// Every tower should attack and stop attacking.
		/// Implementation will differ from one tower to another
		/// </summary>
		protected abstract void AttackTarget();
		protected abstract void StopAttacking();








		//Testing tool to visualize range in the editor
		private void OnDrawGizmos()
		{
			Gizmos.DrawWireSphere(transform.position, towerType.GetTowerRange());
		}
	}
}


