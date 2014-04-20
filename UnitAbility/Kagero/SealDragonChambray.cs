using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Soul Blast (1)] When this unit boosts a unit with "
 * Blockade" in its card name, you may pay the cost. If you do, 
 * the boosted unit gets [Power]+6000 until end of that battle.
 */

public class SealDragonChambray : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC()
			   && CanSoulBlast(1)
			   && tmp.name.Contains("Blockade"))
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active ()
	{
		ShowAndDelay();
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
