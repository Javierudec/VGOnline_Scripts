using UnityEngine;
using System.Collections;

public class RevengerOfMaliceDilan : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;

			if(RC()
			   && CanSoulBlast(1)
			   && tmp.cardID == CardIdentifier.REVENGER__RAGING_FORM_DRAGON)
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
