using UnityEngine;

namespace TowersNoDragons.AI
{
	public class Vampire : Enemy
	{
		[SerializeField] private float hpRegen = 5f;

		private void Update()
		{
			base.hp += hpRegen;
			base.hp = Mathf.Clamp(base.hp, 0f, base.maxHp);
			base.eventHandler.OnUI_HP_Update(base.hp / base.maxHp);

			//TODO: Add healing VFX
		}

		public override string ToString()
		{
			return "Physical";
		}
	}
}

