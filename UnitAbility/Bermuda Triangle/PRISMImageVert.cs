using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):When a «Bermuda Triangle» rides this unit, draw a card, 
 * choose up to two of your «Bermuda Triangle» rear-guards, return them 
 * to your hand, choose your vanguard, and that unit gets [Power]+10000 
 * until end of turn.
 * 
 * [CONT](VC):During your turn, if the number of «Bermuda Triangle» 
 * rear-guards you have is four or more, this unit gets [Power]+2000.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this 
 * unit, this unit cannot attack)
 */

public class PRISMImageVert : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(IsPlayerTurn() && NumUnits(delegate(Card c) { return c.BelongsToClan("Bermuda Triangle"); }) >= 4)
		{
			power += 2000;	
		}
		SetPower(power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().BelongsToClan("Bermuda Triangle") && LimitBreak(4))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			int numUnits = min(2, NumUnits(delegate(Card c) { return c.BelongsToClan("Bermuda Triangle"); }));
			SelectUnit("Choose up to " + numUnits + " of your \"Bermuda Triangle\" rear-guards.", numUnits, true,
			delegate {
				ReturnToHand(Unit);
			},
			delegate {
				return Unit.BelongsToClan("Bermuda Triangle");
			},
			delegate {
				IncreasePowerByTurn(GetVanguard(), 10000);
			});
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer(true);
	}
}
