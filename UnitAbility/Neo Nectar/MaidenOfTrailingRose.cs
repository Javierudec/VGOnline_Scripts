using UnityEngine;
using System.Collections;

public class MaidenOfTrailingRose : UnitObject {
	public override void Cont()
	{
		if(NumUnits (delegate(Card c) { return !c.BelongsToClan("Neo Nectar"); }) > 0)
		{
			AddContPower(-2000);
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.AttackHits)
		{
			if(OwnerCard.IsVanguard() &&
			   GetDefensor().IsVanguard() &&
			   CB(1) &&
			   Game.playerHand.GetByID(OwnerCard.cardID) != null &&
			   Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active()
	{
		FlipCardInDamageZone(1);
		ShowAndDelay();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose a " + OwnerCard.name + " from your hand.");
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
			EndEffect();
			ShuffleDeck();
		});
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c) && c.cardID == OwnerCard.cardID)
			{
				DiscardSelectedCard();
				ClearPointer(false);
				int top = 5;
				if(top > Game.playerDeck.Size())
				{
					top = Game.playerDeck.Size();	
				}
				Game.playerDeck.ViewDeck(2, SearchMode.TOP_CARD, top, "Neo Nectar");
				SetBool(1);
			}
		}
	}
}
