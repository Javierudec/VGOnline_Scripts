using UnityEngine;
using System.Collections;

public class AmberDragonDaylight : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID (CardIdentifier.AMBER_DRAGON__DAWN) != null)
		{
			AddContPower(2000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Call)
		{
			if(Game.playerHand.GetNumberOfCardsWithClanNameAndGrade("Kagero", 3) > 0 &&
			   Game.playerDeck.SearchForID(CardIdentifier.AMBER_DRAGON__ECLIPSE) != null)
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
			EnableMouse("Choose a grade 3 Kagero from your hand.");	
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
				FromDeckToHand(CardIdentifier.AMBER_DRAGON__ECLIPSE);
				ShuffleDeck();
				ClearPointer();				
			}
		}
	}
}
