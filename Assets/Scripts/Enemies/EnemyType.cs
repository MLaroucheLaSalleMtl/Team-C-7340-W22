using UnityEngine;

namespace TowersNoDragons.EnemyTypes
{
	[CreateAssetMenu(fileName = "Data", menuName = "Enemies/New Enemy")]
	public class EnemyType : ScriptableObject
	{
		[SerializeField] private float movementSpeed = 25f; //nav-agent speed

		public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
	}
}


