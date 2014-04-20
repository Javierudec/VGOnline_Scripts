using UnityEngine;
using System.Collections;

public class SternBlaukluger : UnitObject {
	int _AuxInt;

	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID(CardIdentifier.BLAUKLUGER) != null)
		{
			AddContPower(1000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.AttackHits)
		{	
			if(GetDefensor().IsVanguard() &&
			   CB(2) && 
			   Game.playerHand.GetNumberOfCardsWithClanName("Nova Grappler") >= 2 &&
			   OwnerCard.IsVanguard())
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();
		FlipCardInDamageZone(2);
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose two Nova Grappler cards from your hand.");	
		});
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(c != null && c._HandleMouse.mouseOn && c.clan == "Nova Grappler")
			{
				DiscardSelectedCard();
				_AuxInt--;
				if(_AuxInt <= 0)
				{
					DisableMouse();
					ClearMessage();
					EndEffect();
					StandUnit(OwnerCard);
					Card c2 = Game.field.GetCardAt(fieldPositions.REAR_GUARD_CENTER);
					if(c != null)
					{
						StandUnit(c2);	
					}
					OwnerCard.bDisableTwinDrive = true; 
				}
			}
		}
	}
}
