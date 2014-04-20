using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (1)] When this unit is returned to your 
 * hand from (RC), if you have a «Bermuda Triangle» vanguard, 
 * you may pay the cost. If you do, Soul Charge (1), and draw a card.
 */

public class RainbowLightCarine : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.HandFromRear)
		{
			if(CB(1)
			   && VanguardIs("Bermuda Triangle")
			   && GetDeck ().Size() >= 2)
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
			DrawCard(1);
		});

		DrawCardUpdate(delegate {
			EndEffect();
		});
	}
}
