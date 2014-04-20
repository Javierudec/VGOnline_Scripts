using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Counter Blast (1)] When an attack by your vanguard with 
 * "Blau" in its card name hits a vanguard, you may pay the cost. If you do, 
 * [Stand] this unit, and this unit gets [Power]+5000 until the end of turn.
 */

public class FlowerLeiLeprechaun : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			if(RC () && CB (1) && GetAttacker().IsVanguard() && GetAttacker().name.Contains("Blau") && GetDefensor().IsVanguard())
			{
				DisplayConfirmationWindow();	
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
			CounterBlast(1,
			delegate {
				StandUnit(Unit);
				IncreasePowerByTurn(OwnerCard, 5000);
				EndEffect();
			});
		});
	}
	
	public override void Pointer()
	{
		CounterBlast_Pointer();	
	}
}
