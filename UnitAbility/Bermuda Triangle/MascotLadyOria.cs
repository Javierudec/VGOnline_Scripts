using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Counter Blast(1)] When this unit boosts a «Bermuda Triangle» 
 * that has Limit Break 4, you may pay the cost. If you do, the boosted unit 
 * gets [Power]+3000 until end of that battle.
 */

public class MascotLadyOria : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(tmp != null && tmp.BelongsToClan("Bermuda Triangle") && tmp.bHasLimitBreak4 && RC() && CB(1))
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
			CounterBlast(1,
			delegate {
				IncreasePowerByBattle(OwnerCard.boostedUnit, 3000);	
				EndEffect();
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
