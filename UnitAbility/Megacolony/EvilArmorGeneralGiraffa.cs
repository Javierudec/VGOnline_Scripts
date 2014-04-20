using UnityEngine;
using System.Collections;

public class EvilArmorGeneralGiraffa : UnitObject {
	int _AuxInt2;
	int _AuxInt;

	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID(CardIdentifier.ELITE_MUTANT__GIRAFFA) != null)
		{
			AddContPower(1000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() &&
			   NumUnits (delegate(Card c) { return c.BelongsToClan("Megacolony"); }) >= 2 &&
			   CB(2) &&
			   Game.enemyField.GetNumberOfRearUnitsWithGradeLessOrEqual(1) > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Active()
	{
		StartEffect();
		FlipCardInDamageZone(2);
		ShowAndDelay();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose two of your Megacolony rear-guards.");	
			_AuxInt = 2;
		});
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			
			if(!GetBool(1))
			{
				if(IsRearGuard(p))
				{
					Card c = Game.field.GetCardAt(p);
					if(c != null && c.clan == "Megacolony")
					{
						RetireUnit(c);
						_AuxInt--;
						if(_AuxInt <= 0)
						{
							SetBool(1);
							DisplayHelpMessage("Choose up to two of your opponent's grade 1 or less rear-guards.");
							_AuxInt2 = 2;
							if(_AuxInt2 > Game.enemyField.GetNumberOfRearUnitsWithGradeLessOrEqual(1))
							{	
								_AuxInt2 = Game.enemyField.GetNumberOfRearUnitsWithGradeLessOrEqual(1);
							}
						}
					}
				}
			}
			else
			{
				if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
				{
					Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
					if(c != null && c.grade <= 1)
					{
						RetireEnemyUnit(c);
						_AuxInt2--;
						if(_AuxInt2 <= 0)
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
