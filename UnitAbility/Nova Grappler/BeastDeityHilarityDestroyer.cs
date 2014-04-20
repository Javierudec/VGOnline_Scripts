using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Choose a card from your hand, and 
 * discard it] When this unit's attack hits a vanguard, 
 * if you have a vanguard with "Beast Deity" in its card 
 * name, you may pay the cost. If you do, draw a card.
 */

public class BeastDeityHilarityDestroyer : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(GetDefensor ().IsVanguard()
			   && GetVanguard ().name.Contains("Beast Deity")
			   && HandSize() > 0
			   && GetDeck ().Size () > 0)
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
			EndEffect();
		});
	}
}
