using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (2)] When this unit is placed on (VC) or (RC), if you 
 * have a vanguard with "Liberator" in its card name, you may pay the cost. If 
 * you do, choose one of your opponent's rear-guards in the front row, and 
 * retire it.
 */

public class BlasterBladeLiberator : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB(2) && GetVanguard().name.Contains("Liberator") && NumEnemyUnits(delegate(Card c) { return c.pos == fieldPositions.ENEMY_FRONT_LEFT || c.pos == fieldPositions.ENEMY_FRONT_RIGHT; }) > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SelectEnemyUnit("Choose one of your opponent's rear-guards in the front row.", 1, true,
				delegate {
					RetireEnemyUnit(EnemyUnit);
				},
				delegate {
					return EnemyUnit.pos == fieldPositions.ENEMY_FRONT_LEFT || EnemyUnit.pos == fieldPositions.ENEMY_FRONT_RIGHT;
				},
				delegate {
					
				});
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectEnemyUnit_Pointer();
	}
}
