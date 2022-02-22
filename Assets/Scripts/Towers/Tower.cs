/*
 * Main Tower class that stores all the common and shared variables and functions 
 * for every tower
 */

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


		//Attacking variables
		private Collider[] enemyCollided;
		protected Enemy target = null;
		private bool isAttacking = false;
		private float attackTimer = 0f; //timer to track the attack cooldown
		private bool canAttack = false;
		private BuildHandler buildingBase = null; //the reference to the base that built this tower | when we sell the tower it should "show" again
		private readonly float spawningSpeed = 35f; //how fast the towe spawns from bottom up

		private void Start()
		{
			enemyCollided = new Collider[10];
			attackTimer = towerType.GetAttackDelay();
			StartCoroutine(PositionTower());
		}

		private void Update()
		{
			if (!canAttack) { return; } //not fully spawned yet from the ground up

			if (target == null)
			{
				isAttacking = false;
				this.StopAttacking();
				return;
			}

			attackTimer += Time.deltaTime;
			attackTimer = Mathf.Clamp(attackTimer, 0, towerType.GetAttackDelay());

			ProcessAttack();

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

		//The actual attack call based on the attackTimer 
		private void ProcessAttack()
		{
			if (isAttacking && attackTimer >= towerType.GetAttackDelay())
			{
				AttackTarget();
				attackTimer = 0f;
			}
		}

		//Shpere search for a compatible collider of type "Enemy"
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

		//keep the collided array clean and updated
		private void ClearEnemiesArray()
		{
			for (int i = 0; i < enemyCollided.Length; i++)
			{
				enemyCollided[i] = null;
			}
		}

		//called one time on build
		private IEnumerator PositionTower()
		{
			while (transform.position.y < spawningHeight_Y)
			{
				transform.Translate(Vector3.up * spawningSpeed * Time.deltaTime);
				yield return null;
			}

			canAttack = true; //fully spawned
		}

		//keep reference to the exact build spot
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








		//Testing tool to visualize the range in the editor
		private void OnDrawGizmos()
		{
			if(towerType == null) { return; }
			Gizmos.DrawWireSphere(transform.position, towerType.GetTowerRange());
		}
	}
}


