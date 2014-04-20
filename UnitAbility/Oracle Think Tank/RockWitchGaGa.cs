using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):When this unit attacks, if you do not have any cards in your soul,
 * draw a card, choose a card from your hand, and put it on the bottom of your deck.
 */

public class RockWitchGaGa : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(CardsInSoul() == 0 && GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			SelectInHand(1, true,
			delegate {
				ReturnCardFromHandToDeck(true, false);
			},
			delegate {
				return true;
			},
			delegate {
				ConfirmAttack();
			}, "Choose a card from your hand.");
		});
	}
	
	public override void Pointer ()
	{
		SelectInHand_Pointer();
	}
}

