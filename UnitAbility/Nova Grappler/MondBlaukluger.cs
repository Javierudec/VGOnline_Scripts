using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):When a «Nova Grappler» rides this unit, choose your vanguard, 
 * and until end of turn, that unit gets [Power]+10000 and "[AUTO](VC):
 * [Counter Blast (1)] When this unit attacks a vanguard, you may pay the cost. 
 * If you do, [Stand] all of your «Nova Grappler» rear-guards.".
 * 
 * [AUTO](VC):When this unit is boosted by a «Nova Grappler», this unit gets 
 * [Power]+2000 until end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class MondBlaukluger : UnitObject {
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
			if(tmp != null && tmp.BelongsToClan("Nova Grappler"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			IncreasePowerByTurn(GetVanguard(), 10000);
			GetVanguard().unitAbilities.AddUnitObject(new MondBlauklugerExternEffect());
			EndEffect();
		});
	}
}

public class MondBlauklugerExternEffect : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard() && VC () && CB (1))
			{		
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();	
	}
	
	public override void Update ()
	{
		Debug.Log("Updating extern method.");
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				ForEachUnitOnField(delegate(Card c) {
					if(!c.IsVanguard())
					{
						StandUnit(c);	
					}
				});
				EndEffect();
			});
		});
	}
	
	public override void Pointer()
	{
		CounterBlast_Pointer();	
	}
}
