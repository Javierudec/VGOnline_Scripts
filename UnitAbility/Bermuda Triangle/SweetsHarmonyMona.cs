using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (1)] When this unit is placed on (RC), if you 
 * have a «Bermuda Triangle» vanguard, you may pay the cost. If you 
 * do, choose another of your «Bermuda Triangle» rear-guards, and 
 * return it to your hand.
 */

public class SweetsHarmonyMona : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(CB (1) && VanguardIs("Bermuda Triangle") && NumUnits(delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Bermuda Triangle"); }) > 0)
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
				SelectUnit("Choose another of your \"Bermuda Triangle\" rear-guards.", 1, true,
				delegate {
					ReturnToHand(Unit);
				},
				delegate {
					return Unit != OwnerCard && Unit.BelongsToClan("Bermuda Triangle");
				},
				delegate {
					
				});
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectUnit_Pointer();
	}
}
