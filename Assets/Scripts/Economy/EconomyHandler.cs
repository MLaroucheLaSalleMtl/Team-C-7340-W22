using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowersNoDragons.Economy
{
    public class EconomyHandler : MonoBehaviour
    {
        public static EconomyHandler Instance;

        [SerializeField] private int playerGold = 1000;

        private void Awake()
        {
            Instance = this;
        }

        public void AddGold(int toAdd)
        {
            playerGold += toAdd;
        }

        public void SubtractGold(int toReduce)
        {
            playerGold -= toReduce;
        }

        public int GetCurrentGold()
        {
            return playerGold;
        }
    }
}

