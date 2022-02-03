using System.Collections;
using System.Collections.Generic;
using TowersNoDragons.AI;
using UnityEngine;

namespace TowersNoDragons.Waves
{
	[CreateAssetMenu(fileName = "Data", menuName = "Waves/New Wave")]
	public class Wave : ScriptableObject
	{
		[SerializeField] private EnemiesToSpawn[] enemiesToSpawn;

		[System.Serializable]
		public class EnemiesToSpawn
		{
			[SerializeField] private Enemy enemyPrefab = null;
			[SerializeField] private int amount;

			public int GetAmount()
			{
				return amount;
			}
		}

		public EnemiesToSpawn GetFirstTypeEnemy() //remove test later
		{
			return enemiesToSpawn[0];
		}

	}

}

