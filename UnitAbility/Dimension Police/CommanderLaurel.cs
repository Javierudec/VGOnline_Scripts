using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Choose four of your «Dimension Police» rear-guards,
 * and [Rest] them] When your «Dimension Police» vanguard's attack hits,
 * you may pay the cost. If you do, choose one of your vanguards, and [Stand] it.
 */

public class CommanderLaurel : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			if(RC ()
			   && GetAttacker().IsVanguard()
			   && GetAttacker().BelongsToClan("Dimension Police")
			   && NumUnits(delegate(Card c) { return c.IsStand() && c.BelongsToClan("Dimension Police"); }) >= 4)
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
			SelectUnit("Choose four of your \"Dimension Police\".", 4, true,
			delegate {
				RestUnit(Unit);
			},
			delegate {
				return Unit.IsStand() && Unit.BelongsToClan("Dimension Police");
			},
			delegate {
				StandUnit(GetVanguard());
			});
		});
	}
}
