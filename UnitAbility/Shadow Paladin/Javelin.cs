using UnityEngine;
using System.Collections;

public class Javelin : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID(CardIdentifier.FULLBAU) != null)
		{
			AddContPower(2000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Call)
		{
			if(Game.playerHand.GetNumberOfCardsWithClanNameAndGrade("Shadow Paladin", 3) > 0 &&
			   Game.playerDeck.SearchForID(CardIdentifier.PHANTOM_BLASTER_DRAGON) != null)
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
			EnableMouse("Choose a card from your hand.");
		});
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c) && c.clan == "Shadow Paladin" && c.grade == 3)
			{
				DiscardSelectedCard();
				FromDeckToHand(CardIdentifier.PHANTOM_BLASTER_DRAGON);
				DisableMouse();
				ClearMessage();
				EndEffect();
			}
		}
	}
}
