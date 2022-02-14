using UnityEngine;
using UnityEngine.UI;

namespace TowersNoDragons.UI
{
    public class UpdateHealthUI : MonoBehaviour
    {
      [SerializeField] private GameObject HP_Container = null;
      [SerializeField] private Image hpBarImage = null;

      public void Update_HP_UI(float amount)
	  {
            HP_Container.SetActive(true);
            hpBarImage.fillAmount = amount;

      }
    }
}


