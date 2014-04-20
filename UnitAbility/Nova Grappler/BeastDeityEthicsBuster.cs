using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):When a «Nova Grappler» rides this unit, choose your vanguard, 
 * and until end of turn, that unit gets [Power]+10000 and "[AUTO](VC):When 
 * this unit attacks a vanguard, [Stand] all of your «Nova Grappler» rear-guards 
 * in the front row.".
 * 
 * [AUTO](VC):When this unit is boosted by a «Nova Grappler», this unit gets 
 * [Power]+2000 until end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class BeastDeityEthicsBuster : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(LimitBreak(4) && VanguardIs("Nova Grappler"))
			{
				StartEffect();
				ShowAndDelay();
			}
		}	
		else if(cs == CardState.IsBoosted)
		{
			Card tmp = OwnerCard.IsBoostedBy;
			if(VC() && tmp != null && tmp.BelongsToClan("Nova Grappler"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate (delegate {
			IncreasePowerByTurn(GetVanguard(), 10000);
			GetVanguard().unitAbilities.AddUnitObject(new BeastDeityEthicsBusterEXT());
			EndEffect();
		});
	}
}

public class BeastDeityEthicsBusterEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC() && GetDefensor().IsVanguard())
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			ForEachUnitOnField(delegate(Card c) {
				if(c.BelongsToClan("Nova Grappler") && (c.pos == fieldPositions.FRONT_GUARD_LEFT || c.pos == fieldPositions.FRONT_GUARD_RIGHT))
				{
					StandUnit(c);	
				}
			});
			EndEffect();
		});
	}
}