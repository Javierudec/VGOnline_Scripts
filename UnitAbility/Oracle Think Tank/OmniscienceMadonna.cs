using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Choose a card from your hand, and discard it] When 
 * this unit's attack hits, if you have an «Oracle Think Tank» vanguard, 
 * you may pay the cost. If you do, draw a card.
 */

public class OmniscienceMadonna : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetHand().Size() > 0 && VanguardIs("Oracle Think Tank") && GetDeck().Size() > 0)
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
				DrawCardWithoutDelay();
			}, "Choose a card from your hand.");
		});
	}
	
	public override void Pointer ()
	{
		SelectInHand_Pointer();
	}
}
