using UnityEngine;
using System.Collections;

public class Tsukuyomi : UnitObject {
	public override void Cont()
	{
		if(Game.field.GetSoulByID(CardIdentifier.GODDESS_OF_THE_HALF_MOON__TSUKUYOMI) == null ||
		   Game.field.GetSoulByID(CardIdentifier.GODDESS_OF_THE_CRESCENT_MOON__TSUKUYOMI) == null ||
		   Game.field.GetSoulByID(CardIdentifier.GODHAWK__ICHIBYOSHI) == null)
		{
			AddContPower(-2000);
		}
	}
	
	public override int Act()
	{
		if(OwnerCard.IsVanguard() && Game.field.GetNumberOfDamageCardsFaceup() >= 2 &&
		   Game.field.GetUnitsSoulWithClanName("Oracle Think Tank") >= 6)
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active()
	{
		ShowOnScreen();
		FlipCardInDamageZone(2);
		DrawCard(2);
		StartEffect();
	}
	
	public override void Update()
	{
		DrawCardUpdate(delegate {
			EnableMouse();
			DisplayHelpMessage("Choose a card from your hand an put it into your soul.");
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
