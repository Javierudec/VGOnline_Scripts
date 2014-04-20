using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (2)] When this unit is placed on (VC) or (RC), if 
 * you have a vanguard with "Revenger" in its card name, you may pay 
 * the cost. If you do, choose one of your opponent's rear-guards in the 
 * front row, and retire it.
 */

public class BlasterDarkRevenger : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB(2) && GetVanguard().name.Contains("Revenger"))
			{
				if(NumEnemyUnits(delegate(Card c) { return IsFrontRow(c); }) > 0)
				{
					DisplayConfirmationWindow();	
				}
			}
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update()
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
	
	public override void Pointer()
	{
		CounterBlast_Pointer();	
		SelectEnemyUnit_Pointer();
	}
}
