using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (1) - «Angel Feather»] When this unit attacks, 
 * if you have an «Angel Feather» vanguard, you may pay the cost. If you do, 
 * this unit gets [Power]+4000 until end of that battle.
 */

public class DoctroidArgus : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VanguardIs("Angel Feather")
			   && CB(1, delegate(Card c) { return c.BelongsToClan("Angel Feather"); }))
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
				IncreasePowerByBattle(OwnerCard, 4000);
				EndEffect();
			},
			delegate(Card c) {
				return c.BelongsToClan("Angel Feather");
			});
		});
	}
}
