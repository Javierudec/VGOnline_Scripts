using UnityEngine;
using System.Collections;

public class TailJoe : UnitObject {
	public override void Cont()
	{	
		if(IsPlayerTurn() &&
		   Game.enemyField.GetNumberOfRearGuardRested() == Game.enemyField.GetNumberOfRearUnits() &&
		   !Game.enemyField.GetCardAt(EnemyFieldPosition.VANGUARD).IsStand())
		{
			AddContPower(3000);	
		}
	}
}
