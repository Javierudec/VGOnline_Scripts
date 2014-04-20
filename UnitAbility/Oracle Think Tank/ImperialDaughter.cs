using UnityEngine;
using System.Collections;

public class ImperialDaughter : UnitObject {
	public override void Cont()
	{
		if(Game.field.GetNumberOfRear() == 0 && OwnerCard.IsVanguard() && IsPlayerTurn())
		{
			AddContPower(10000);
			AddContCritical(1);
			if(OwnerCard.bRestraintVanguard)
			{
				OwnerCard.RemoveRestraint();	
			}
		}
		else
		{
			if(!_AuxBool)
			{
				OwnerCard.bRestraintVanguard = true;
			}
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.EndTurn)
		{
			_AuxBool = false;	
		}
	}
	
	public override int Act()
	{
		if(Game.field.GetNumberOfDamageCardsFaceup() >= 1)
		{
			if(OwnerCard.IsVanguard() && Game.field.GetNumberOfRearWithClanName("Oracle Think Tank") > 0)
			{
				return 1;	
			}
			
			if(!OwnerCard.IsVanguard() && Game.field.GetNumberOfRearWithClanName("Oracle Think Tank") > 1)
			{
				return 1;	
			}
		}
		
		return 0;
	}
	
	public override void Active()
	{
		ShowOnScreen();
		StartEffect();
		EnableMouse();
		DisplayHelpMessage("Choose one of your Oracle Think Tank rear-guards.");
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != OwnerCard && c.clan == "Oracle Think Tank")
				{
					MoveToSoul(c);
					OwnerCard.RemoveRestraint();
					_AuxBool = true;
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
}
