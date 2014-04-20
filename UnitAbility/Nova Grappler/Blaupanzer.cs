using UnityEngine;
using System.Collections;

public class Blaupanzer : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID (CardIdentifier.BLAUJUNGER) != null)
		{
			AddContPower(2000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Call)
		{
			if(Game.playerHand.GetNumberOfCardsWithClanNameAndGrade("Nova Grappler", 3) > 0 &&
			   Game.playerDeck.SearchForID(CardIdentifier.STERN_BLAUKLUGER) != null)
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
			EnableMouse("Choose a grade 3 Nova Grappler from your hand.");	
		});
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c) &&
			   c.clan == "Kagero" &&
			   c.grade == 3)
			{
				DiscardSelectedCard();
				FromDeckToHand(CardIdentifier.STERN_BLAUKLUGER);
				ShuffleDeck();
				ClearPointer();				
			}
		}
	}
}
