using TowersNoDragons.AI;
using TowersNoDragons.AttackTypes;
using UnityEngine;

namespace TowersNoDragons.Projectiles
{
	public class Arrow : MonoBehaviour
	{
		[SerializeField] private float projectileSpeed = 10f;
		[SerializeField] private float damage = 20f;
		[SerializeField] private DamageTypes damageType = new DamageTypes();
		[SerializeField] private Rigidbody rb = null;
	    
		private Transform target; 
		private const string enemyTag = "Enemy";
		
		private void Update()
		{
			if (target == null) { Destroy(gameObject); return; }

			transform.LookAt(target.position);
			transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
		}


		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag(enemyTag))
			{
				other.GetComponent<Enemy>().TakeDamage(damage,damageType);
				Destroy(gameObject);
			}
			else
			{
				rb.isKinematic = true;
				Destroy(gameObject,4f); 
			}
				
		}

		public void AssignTarget(Transform target)
		{
			this.target = target;
		}
	}
}


