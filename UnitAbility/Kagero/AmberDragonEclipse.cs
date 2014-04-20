using UnityEngine;
using System.Collections;

public class AmberDragonEclipse : UnitObject {
	int _AuxInt;

	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID(CardIdentifier.AMBER_DRAGON__DUSK) != null)
		{
			AddContPower(1000);	
		}
	}
	
	public override int Act()
	{
		if(OwnerCard.IsVanguard() &&
		   CB(2))
		{
			return 1;	
		}
		return 0;	
	}
	
	public override void Active()
	{
		ShowAndDelay();
		SetBool(2);
		FlipCardInDamageZone(2);
		SetBool(1);
		StartEffect();
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.AttackHits)
		{
			if(OwnerCard.IsVanguard() &&
			   GetBool(1) &&
			   GetDefensor().IsVanguard() &&
			   Game.enemyField.GetNumberOfRearUnits() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}	
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(1);	
		}
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			if(GetBool(2))
			{
				UnsetBool(2);
				EndEffect();
			}
			else
			{
				EnableMouse("Choose up to two of your opponent's rear-guards.");
				_AuxInt = 2;
				if(_AuxInt > Game.enemyField.GetNumberOfRearUnits())
				{
					_AuxInt = Game.enemyField.GetNumberOfRearUnits();	
				}
			}
		});
	}
	
	public override void Pointer()
	{
		if(AcceptInput())	
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null)
				{
					RetireEnemyUnit(c);
					_AuxInt--;
					if(_AuxInt <= 0)
					{
						ClearMessage();
						DisableMouse();
						EndEffect();
					}
				}
			}
		}
	}
}
