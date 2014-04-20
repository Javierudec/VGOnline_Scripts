using UnityEngine;
using System.Collections;

public class TopIdolRiviere : UnitObject {
	int _AuxInt;

	public override void Cont()
	{
		if(OwnerCard.IsVanguard() && Game.field.GetSoulByID(CardIdentifier.SUPER_IDOL__RIVIERE) != null)
		{
			AddContPower(1000);	
		}
	}
	
	public override void Auto(CardState s, Card effectOwner)
	{
		if(s == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() && 
			   CB(2) &&
			   Game.playerHand.GetByID(CardIdentifier.TOP_IDOL__RIVIERE) != null &&
			   Game.field.GetNumberOfRear() > 0)
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
			EnableMouse("Choose a card named \"Top Idol, Riviere\" from your hand.");
		});
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			if(!GetBool(1))
			{
				Card c = HandSelectedCard();
				if(c != null && c._HandleMouse.mouseOn && c.cardID == CardIdentifier.TOP_IDOL__RIVIERE)
				{
					DiscardSelectedCard();	
					DisplayHelpMessage("Choose up to three Bermuda Triangle rear-guards.");
					SetBool(1);
					_AuxInt = 3;
					if(Game.field.GetNumberOfRear() < _AuxInt)
					{
						_AuxInt = Game.field.GetNumberOfRear();	
					}
					//UnblockAllZones();
				}
			}
			else
			{
				fieldPositions p = Util.GetMousePosition();
				if(IsRearGuard(p))// && !IsBlocked(p))
				{
					Card c = Game.field.GetCardAt(p);
					if(c.clan == "Bermuda Triangle")
					{
						IncreasePowerByTurn(c, 5000);
						_AuxInt--;
						if(_AuxInt <= 0)
						{
							DisableMouse();
							ClearMessage();
							EndEffect();
							UnsetBool(1);
						}
					}
				}
			}	
		}
	}
}
