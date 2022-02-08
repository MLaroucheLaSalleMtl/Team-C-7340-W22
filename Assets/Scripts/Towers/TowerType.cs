using UnityEngine;

namespace TowersNoDragons.TowerTypes
{
    [CreateAssetMenu(fileName = "Data", menuName = "Towers/New Tower")]
    public class TowerType : ScriptableObject
    {
        [SerializeField] private float towerRange = 5f; //tower range
        [SerializeField] private int towerPrice = 100; //gold
        [SerializeField] private float damage = 10f;
        [SerializeField] int startingLevel = 1;
        [SerializeField] float attackDelay = 2f;

        //for upgrades
        [Header("Level 2 Stats")][SerializeField] float level_2_Damage = 5f;


        //Getters
        public float GetTowerRange()
		{
            return towerRange;
		}

        public float GetTowerPrice()
        {
            return towerPrice;
        }

        public float GetAttackDelay()
		{
            return attackDelay;
        }

        public float GetDamage()
		{
            return damage;
		}

        //Upgrade Functions
        public void LevelUp()
		{
            damage = level_2_Damage;

        }
    }
}


