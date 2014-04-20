using UnityEngine;
using System.Collections;

public class AmonsFollowerFoolsPalm : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(NumUnitsInSoul(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) >= 6
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
