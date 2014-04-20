using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (1)] When this unit attacks a vanguard, if you 
 * have an «Oracle Think Tank» vanguard, you may pay the cost. If you do, 
 * declare the card name of an «Oracle Think Tank», and reveal the top card of 
 * your deck. If the revealed card is the card that you declared, put it your hand, 
 * and if it is not, choose a card from your damage zone, and turn it face up.
 */

public class StellarMagus : UnitObject {
	string name;
	Card revealedCard;
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard() && CB (1) && VanguardIs("Oracle Think Tank") && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void SelectionCardNameOnClose (string nameSelected)
	{
		name = nameSelected;
		revealedCard = RevealTopCard();
		//ShowOnScreen(revealedCard);
		Delay(1);
		SetBool(1);
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			if(!GetBool(1))
			{
				CounterBlast(1,
				delegate {
					OpenSelectionCardNameList(OwnerCard, "Declare the name of an \"Oracle Think Tank\".", delegate(CardInformation c) {
						return c.BelongsToClan("Oracle Think Tank");
					});
				});
			}
			else
			{
				HideTopCard();
				UnsetBool(1);
				if(revealedCard.name == name)
				{
					FromDeckToHand(revealedCard.cardID);
					EndEffect();
					ConfirmAttack();
				}
				else
				{
					Flipup(1,
					delegate {
						EndEffect();	
						ConfirmAttack();
					});
				}
			}
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		Flipup_Pointer();
	}
}
