using UnityEngine;
using System.Collections;

public class FangOfLightGarmore : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() && IsPlayerTurn())
		{
			Game.field.InitFieldIterator();
			while(Game.field.HasNextField())
			{
				Card c = Game.field.CurrentFieldCard();
				if(c != null && !c.IsVanguard() && (c.cardID == CardIdentifier.SNOGAL || c.cardID == CardIdentifier.BRUGAL))
				{
					AddContPower(1000);	
				}
			}
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetVanguard().clan == "Royal Paladin" &&
			   Game.playerHand.GetNumberOfCardsWithClanName("Royal Paladin") > 0 &&
			   (Game.playerDeck.SearchForID(CardIdentifier.BRUGAL) != null ||
			 	Game.playerDeck.SearchForID(CardIdentifier.SNOGAL) != null))
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
			EnableMouse("Choose one card from your hand.");	
		});	
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				CallFromDeck(Game.playerDeck.GetLastSelectedList());
			}
		}
		
		CallFromDeckUpdate(delegate {
			ShuffleDeck();
			EndEffect();	
		});
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(c != null && c._HandleMouse.mouseOn && c.clan == "Royal Paladin")
			{
				DiscardSelectedCard();	
				Game.playerDeck.ViewDeck(CardIdentifier.SNOGAL, CardIdentifier.BRUGAL);
				SetBool(1);
				DisableMouse();
				ClearMessage();
			}
		}
	}
}
