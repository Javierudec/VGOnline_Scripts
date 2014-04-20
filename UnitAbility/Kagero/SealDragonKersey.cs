using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Choose a card from your hand, and discard it] When this
 * unit is placed on (RC), if you have a «Kagerō» vanguard, and your 
 * opponent has a grade 2 vanguard or rear-guard, you may pay the cost. 
 * If you do, draw a card.
 */

public class SealDragonKersey : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(GetDeck().Size() > 0
			   && VanguardIs("Kagero")
			   && NumEnemyUnits(delegate(Card c) { return c.grade == 2; }, true) > 0)
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
			SelectInHand(1, true,
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

		DrawCardUpdate(delegate {
			EndEffect();
		});
	}
}
