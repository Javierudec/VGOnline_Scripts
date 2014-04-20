using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage): When a «Royal Paladin» rides this unit, choose your vanguard, 
 * and that unit gets [Power]+10000/[Critical]+1 until end of turn.
 * 
 * [AUTO](VC): When this unit attacks a vanguard, this unit gets [Power]+2000 
 * until end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class PureHeartJewelKnightAshlei : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Royal Paladin") && LimitBreak(4))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC() && GetDefensor().IsVanguard())
			{
				IncreasePowerByTurn(OwnerCard, 2000);	
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			IncreasePowerAndCriticalByTurn(GetVanguard(), 10000, 1);
			EndEffect();
		});
	}
}
