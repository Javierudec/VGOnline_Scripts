using UnityEngine;
using System.Collections;

public class EnigmanRipple : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID(CardIdentifier.ENIGMAN_FLOW) != null)
		{
			AddContPower(2000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Call)
		{
			if(Game.playerHand.GetNumberOfCardsWithClanNameAndGrade("Dimension Police", 3) > 0 &&
			   Game.playerDeck.SearchForID(CardIdentifier.ENIGMAN_STORM) != null)
			{
				StartEffect();
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
			EnableMouse("Choose a grade 3 Dimension Police from your hand.");
		});	
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c) && c.clan == "Dimension Police" && c.grade == 3)
			{
				DiscardSelectedCard();
				FromDeckToHand(CardIdentifier.ENIGMAN_STORM);
				DisableMouse();
				ClearMessage();
				EndEffect();
			}
		}
	}
}
