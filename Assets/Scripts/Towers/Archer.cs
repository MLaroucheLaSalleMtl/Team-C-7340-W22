using TowersNoDragons.AI;
using TowersNoDragons.Projectiles;
using UnityEngine;

namespace TowersNoDragons.Towers
{
	public class Archer : MonoBehaviour
	{
		[Tooltip("How fast the archer rotates towards the enemy")]
		[SerializeField] private float rotationSpeed = 2f;
		[SerializeField] private Arrow projectilePrefab = null;
		[SerializeField] private Transform shootingPoint = null;

		private Enemy target = null;
		private Vector3 targetDirection = new Vector3();
		private Quaternion rotationTarget = new Quaternion();

		//animation
		private Animator animator;

		private void Awake()
		{
			animator = GetComponent<Animator>();
		}

		private void Update()
		{
			if (this.target == null) { return; }

			RotateTowardsTarget();
		}

		public void Attack(Enemy target)
		{
			this.target = target;
			animator.SetBool("IsAttacking", true);
		}

		public void StopAttacking()
		{
			this.target = null;
			animator.SetBool("IsAttacking", false);
		}

		private void RotateTowardsTarget()
		{
			targetDirection = target.transform.position - transform.position;
			targetDirection.y = 0f;
			rotationTarget = Quaternion.LookRotation(targetDirection);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotationTarget, rotationSpeed * Time.deltaTime);
		}

		//Animation Event
		private void AttackTarget()
		{
			if(target == null) { return; }
			var instance = Instantiate(projectilePrefab, shootingPoint); //create an arrow
			instance.AssignTarget(target.transform);
			instance.transform.parent = null;

		}


	}
}


