using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (2)] When this unit attacks, 
 * if you have a «Genesis» vanguard, you may pay the cost.
 * If you do, this unit gets [Power]+5000 until end of that battle.
 */

public class CrimsonWitchRadish : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(CB (2)
			   && VanguardIs("Genesis"))
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active()
	{
		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				IncreasePowerByBattle(OwnerCard, 5000);
				EndEffect();
			});
		});
	}
}
