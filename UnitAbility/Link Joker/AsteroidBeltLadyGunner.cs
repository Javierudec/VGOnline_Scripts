using UnityEngine;
using System.Collections;

public class AsteroidBeltLadyGunner : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC()
			   && HandSize() > 0
			   && GetAttacker() == tmp
			   && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
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
				DrawCardWithoutDelay();
			}, "Choose a card from your hand.");
		});
	}
}
