using UnityEngine;
using System.Collections;

public class SkyDiver : UnitObject {
	public override void Cont()
	{
		if(Game.field.GetNumberOfCardsWithClanName("Spike Brothers") <= 1)
		{
			AddContPower (-2000);	
		}
	}	
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.AttackHits)
		{
			if(Game.playerHand.GetNumberOfCardsWithClanName("Spike Brothers") > 0 && !OwnerCard.IsVanguard())
			{
				Game.bEffectOnGoing = true;
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Active()
	{
		ShowOnScreen(OwnerCard);
		MoveToSoul(OwnerCard);	
		EnableMouse();
		DisplayHelpMessage("Choose one Spike Brothers unit from you hand and call it to RC.");
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			if(!_AuxBool2)
			{
				Card temp = Game.playerHand.GetCurrentCardObject();
				if(temp != null && temp._HandleMouse.mouseOn)
				{
					_AuxBool = true;
					Game.Call();	
					_AuxBool2 = true;
				}
			}
			else
			{
				Game.HandleNormalCall();
				_AuxBool2 = false;
				DisableMouse();
			}
		}
	}
	
	public override void Update()
	{
		if(_AuxBool)
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				_AuxBool = false;
				Game.bEffectOnGoing = false;
				ClearMessage();
			}
		}
	}
}
