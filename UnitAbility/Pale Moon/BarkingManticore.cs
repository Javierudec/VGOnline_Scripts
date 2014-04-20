using UnityEngine;
using System.Collections;

public class BarkingManticore : UnitObject {
	public override void Cont()
	{
		if(IsPlayerTurn() && Game.field.GetSoulByID(CardIdentifier.CRIMSON_BEAST_TAMER) != null)
		{
			AddContPower(3000);	
		}
	}
	
	public override void Auto(CardState s, Card effectOwner)
	{
		if(s == CardState.Ride)
		{
			if(Game.playerDeck.Size() > 0)
			{
				StartEffect();
				ShowOnScreen();
				Delay(1);
			}
		}
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EnableMouse();
			DisplayHelpMessage("Choose one card from your hand.");
		});
		
		FromHandToSoulUpdate(delegate {
			EndEffect();	
		});
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			Card c = Game.playerHand.GetCurrentCardObject();
			if(c != null && c._HandleMouse.mouseOn)
			{
				FromHandToSoul(c, Game.playerHand.GetCurrentCard());	
				ClearMessage();
				DisableMouse();
			}
		}
	}
}
