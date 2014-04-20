using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC): [Choose a card from your hand, and discard it] 
 * When this unit attacks, you may pay the cost. If you do, this 
 * unit gets [Power] +4000 until end of turn.
 */

public class KnightOfRoseMorgana : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(HandSize() > 0)
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
				IncreasePowerByBattle(OwnerCard, 4000);
			}, "Choose one card from your hand.");
		});
	}
}
