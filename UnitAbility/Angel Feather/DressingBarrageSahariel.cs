using UnityEngine;
using System.Collections;

public class DressingBarrageSahariel : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(HandSize() > 0
			   && VanguardIs("Angel Feather")
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
