using UnityEngine;

namespace TowersNoDragons.Utils
{
	public class SelfDestroy : MonoBehaviour
	{
		[SerializeField] private ParticleSystem mainParticleSystem = null;

		private float waitTime;

		private void Awake()
		{
			waitTime = mainParticleSystem.main.duration;
		}

		private void Start()
		{
			Destroy(gameObject, waitTime);
		}
	}
}


