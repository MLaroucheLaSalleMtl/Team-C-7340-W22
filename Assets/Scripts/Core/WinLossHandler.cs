using UnityEngine;

namespace TowersNoDragons.Core
{
    public class WinLossHandler : MonoBehaviour
    {
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private int lives = 10;
        [SerializeField] private int enemiesEliminated = 0;
        [SerializeField] private int totalAmountOfEnemies;

        public static WinLossHandler Instance = null;

		public int TotalAmountOfEnemies { get => totalAmountOfEnemies; set => totalAmountOfEnemies = value; }

		private void Awake()
		{
            if (Instance != null) { Destroy(gameObject); }
            else
            {
                Instance = this;
            }
        }

        //Enemy crossed the finish line
        public void EnemyDetected()
        {
            lives--;
            enemiesEliminated++;
            ProcessWinLoss();
        }

        //Enemy died to a tower
        public void OnTowerKill()
        {
            enemiesEliminated++;
            ProcessWinLoss();
        }

        private void GameLoss()
        {
            Time.timeScale = 0;
            losePanel.SetActive(true);
            print("You lost the game!");
        }

        private void GameWin()
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
            print("You won the game!");
        }


        private void ProcessWinLoss()
		{
            if (lives <= 0)
            {
                GameLoss();
            }

            else if (enemiesEliminated == totalAmountOfEnemies)
            {
                GameWin();
            }
        }
	}
}
