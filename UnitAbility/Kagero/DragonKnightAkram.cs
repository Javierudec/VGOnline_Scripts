using UnityEngine;
using System.Collections;

public class DragonKnightAkram : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC()
			   && CanSoulBlast(1)
			   && tmp.name.Contains("Dauntless"))
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulBlast(1);
		});

		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard.boostedUnit, 6000);
			EndEffect();
		});
	}
}
