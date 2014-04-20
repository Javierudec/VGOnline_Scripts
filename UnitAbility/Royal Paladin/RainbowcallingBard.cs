using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Soul Blast (1)] When this unit boosts a unit named "Sanctuary 
 * Guard Dragon", you may pay the cost. If you do, the boosted unit gets 
 * [Power]+5000 until end of that battle.
 */

public class RainbowcallingBard : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC() && CanSoulBlast(1) && tmp != null && tmp.cardID == CardIdentifier.SANCTUARY_GUARD_DRAGON)
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
			IncreasePowerByBattle(OwnerCard.boostedUnit, 5000);	
			EndEffect();
		});
	}
}
