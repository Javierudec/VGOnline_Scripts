using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (1)] When this unit is returned to your hand from 
 * (RC), if you have a «Bermuda Triangle» vanguard, you may pay the 
 * cost. If you do, Soul Charge (1), and draw a card.
 */

public class GirlsRockRio : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.HandFromRear)
		{
			if(VanguardIs("Bermuda Triangle") && CB (1) && GetDeck().Size() >= 2)
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
				SoulCharge(1);
			});
		});
		
		SoulChargeUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
}
