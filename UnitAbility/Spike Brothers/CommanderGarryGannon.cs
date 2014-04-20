using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Choose a card from your hand, and discard it]
 * When an attack hits during the battle that this unit boosted, 
 * you may pay the cost. If you do, draw a card.
 */

public class CommanderGarryGannon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC () && tmp != null && tmp == GetAttacker() && HandSize() > 0)
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
