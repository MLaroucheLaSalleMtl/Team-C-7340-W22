using UnityEngine;
using TMPro;
using System;

namespace TowersNoDragons.Economy
{
	public class GoldTower : MonoBehaviour
	{
		public event Action onGoldExchange;
		[SerializeField] private int playrGold = 1000;
		[SerializeField] private TMP_Text PlayerGoldText = null;
        private float TimerTimeEnd = 5f;

        private void Start()
        {
            RefreshGold();
        }

        private void RefreshGold()
        {
			PlayerGoldText.text = playrGold.ToString();
        }

		private void AddGold()
        {
            playrGold += 200;
            RefreshGold();
        }

        private void Update()
        {
            TimerTimeEnd -= 1 * Time.deltaTime;
            if (TimerTimeEnd <= 0)
            {
                AddGold();
                TimerTimeEnd = 10f;
            }
            onGoldExchange?.Invoke();
        }
    }
}


