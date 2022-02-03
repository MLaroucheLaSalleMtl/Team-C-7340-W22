using UnityEngine;

namespace TowersNoDragons.Pathing
{
	public class Path : MonoBehaviour
	{
		[SerializeField] private Transform[] waypoints = null;

		public Transform[] GetPath()
		{
			return waypoints;
		}
	}
}


