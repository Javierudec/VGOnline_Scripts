using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):When a «Spike Brothers» rides this unit, choose your vanguard, 
 * and until end of turn, that unit gets [Power]+10000 and "[AUTO](VC):When
 * one of your «Spike Brothers» rear-guards attacks, that unit gets 
 * [Power]+10000 until end of that battle, and at the end of that battle, 
 * put that unit on the bottom of your deck.".
 *
 * [AUTO](VC):When this unit is boosted by a «Spike Brothers», 
 * this unit gets [Power]+2000 until end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as 
 * this unit, this unit cannot attack)
 */

public class BadEndDragger : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(LimitBreak(4) && VanguardIs("Spike Brothers"))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			Card tmp = OwnerCard.IsBoostedBy;
			if(VC() && tmp != null && tmp.BelongsToClan("Spike Brothers"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			IncreasePowerByTurn(GetVanguard(), 10000);	
			GetVanguard().unitAbilities.AddUnitObject(new BadEndDraggerEXT());
			EndEffect();
		});
	}
}

public class BadEndDraggerEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking_NotMe)
		{
			if(VC() && ownerEffect.BelongsToClan("Spike Brothers"))
			{
				IncreasePowerByBattle(ownerEffect, 10000);	
			}
		}
		else if(cs == CardState.EndBattle_NotMe)
		{
			FromFieldToDeck(ownerEffect, true);
		}
	}
}




