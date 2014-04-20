using UnityEngine;
using System.Collections;

public class StrafeStarvaderRuthenium : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC()
			   && CanSoulBlast(1)
			   && tmp.cardID == CardIdentifier.STAR_VADER__NEBULA_LORD_DRAGON)
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
			IncreasePowerByBattle(OwnerCard.boostedUnit, 5000);
			EndEffect();
		});
	}
}
