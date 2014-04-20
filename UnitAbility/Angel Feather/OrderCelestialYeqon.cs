using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Choose a card from your hand, and discard it] When this unit is placed on (RC), 
 * if you have a face up card named "Solidify Celestial, Zerachiel" in your damage zone, 
 * you may pay the cost. If you do, draw a card.
 */

public class OrderCelestialYeqon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(HandSize() > 0
			   && GetDeck ().Size() > 0
			   && NumUnitsDamage(delegate(Card c) { return c.cardID == CardIdentifier.SOLIDIFY_CELESTIAL__ZERACHIEL && c.IsFaceup();}) > 0)
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

		DrawCardUpdate(delegate {
			EndEffect ();
		});
	}
}
