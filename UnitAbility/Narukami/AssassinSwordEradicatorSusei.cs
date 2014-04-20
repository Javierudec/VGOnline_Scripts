using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (2)] When this unit's attack hits a 
 * vanguard, if you have a vanguard with "Eradicator" in its card name, 
 * you may pay the cost. If you do, choose one of your opponent's rear-
 * guards in the front row, and retire it.
 */

public class AssassinSwordEradicatorSusei : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(CB(2) && GetDefensor().IsVanguard() && GetVanguard().name.Contains("Eradicator") &&
				NumEnemyUnits(delegate(Card c) { return IsFrontRow(c); }) > 0)
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
					return IsFrontRow(EnemyUnit);
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

