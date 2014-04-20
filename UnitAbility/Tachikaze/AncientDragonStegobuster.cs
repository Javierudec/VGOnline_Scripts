using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (1)] When this unit attacks, you may pay the cost.
 * If you do, this unit gets [Power]+3000 until end of that battle.
 */

public class AncientDragonStegobuster : UnitObject {
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Attacking)
		{
			if(CB (1))
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
			CounterBlast(1,
			delegate {
				IncreasePowerByBattle(OwnerCard, 3000);
				EndEffect();
			});
		});
	}
}
