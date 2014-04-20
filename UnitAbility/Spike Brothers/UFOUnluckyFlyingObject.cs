using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Choose a card from your hand, and discard it]
 * During your battle phase, when this unit is placed on (RC), 
 * if you have a «Spike Brothers» vanguard, you may pay the cost. 
 * If you do, draw a card.
 */

public class UFOUnluckyFlyingObject : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(CurrentPhaseIs(GamePhase.ATTACK)
			   && HandSize() > 0
			   && VanguardIs("Spike Brothers"))
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
		DelayUpdate (delegate {
			SelectInHand(1, false,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return true;
			},
			delegate {
				DrawCard(1);
			}, "Choose a card from your hand.");
		});

		DrawCardUpdate (delegate {
			EndEffect();
		});
	}
}
