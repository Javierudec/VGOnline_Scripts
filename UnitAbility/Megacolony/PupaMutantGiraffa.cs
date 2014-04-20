using UnityEngine;
using System.Collections;

public class PupaMutantGiraffa : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID (CardIdentifier.LARVA_MUTANT__GIRAFFA) != null)
		{
			AddContPower(2000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Call)
		{
			if(Game.playerHand.GetNumberOfCardsWithClanNameAndGrade("Megacolony", 3) > 0 &&
			   Game.playerDeck.SearchForID(CardIdentifier.EVIL_ARMOR_GENERAL__GIRAFFA) != null)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();	
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose a grade 3 Megacolony from your hand.");	
		});
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c) &&
			   c.clan == "Megacolony" &&
			   c.grade == 3)
			{
				DiscardSelectedCard();
				FromDeckToHand(CardIdentifier.EVIL_ARMOR_GENERAL__GIRAFFA);
				ShuffleDeck();
				ClearPointer();				
			}
		}
	}
}
