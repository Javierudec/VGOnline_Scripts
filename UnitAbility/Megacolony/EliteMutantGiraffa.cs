using UnityEngine;
using System.Collections;

public class EliteMutantGiraffa : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID(CardIdentifier.PUPA_MUTANT__GIRAFFA) != null)
		{
			AddContPower(1000);	
		}
		
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.AttackHits)
		{
			if(OwnerCard.IsVanguard() &&
			   GetDefensor().IsVanguard() &&
			   Game.enemyField.GetNumberOfRearGuardRested() > 0)
			{
				StartEffect();
				ShowAndDelay();	
			}
		}
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one of your opponent's rear guards.");	
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
					CantStandUntilNextTurn(c);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
}
