using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Counter Blast (1)] When this 
 * unit boosts a «Spike Brothers» that has 
 * Limit Break 4, you may pay the cost. If 
 * you do, the boosted unit gets [Power]+3000 
 * until end of that battle
 */

public class TyrantReceiver : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && CB (1)
			   && tmp.BelongsToClan("Spike Brothers")
			   && tmp.bHasLimitBreak4)
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
			CounterBlast(1,
			delegate {
				IncreasePowerByBattle(OwnerCard.boostedUnit, 3000);
				EndEffect();
			});
		});
	}
}
