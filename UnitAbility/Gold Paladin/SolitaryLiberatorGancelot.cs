using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):When a «Gold Paladin» rides this unit, choose your vanguard, and 
 * that unit gets [Power]+10000 until end of turn, and choose up to three of 
 * your «Gold Paladin» rear-guards, and those units get [Power]+5000 until end of turn.
 * 
 * [AUTO](VC):When this unit attacks a vanguard, this unit gets [Power]+2000 
 * until end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class SolitaryLiberatorGancelot : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Gold Paladin") && LimitBreak(4))
			{
				IncreasePowerByTurn(GetVanguard(), 10000);
				if(NumUnits(delegate(Card c) { return c.BelongsToClan("Gold Paladin"); }) > 0)
				{
					StartEffect();
					ShowAndDelay();
				}
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC () && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
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
			int num = NumUnits(delegate(Card c) { return c.BelongsToClan("Gold Paladin"); });
			SelectUnit("Choose up to " + num + " of your \"Gold Paladin\" rear-guards.", num, true,
			delegate {
				IncreasePowerByTurn(Unit, 5000);
			},
			delegate {
				return Unit.BelongsToClan("Gold Paladin");
			},
			delegate {
				
			});
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer(true);
	}
}
