using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Choose one of your rear-guards with "Ancient Dragon" in its card name,
 * and retire it] When this unit attacks a vanguard, if you have a «Tachikaze» vanguard, 
 * you may pay the cost. If you do, this unit gets [Power]+5000 until end of that battle.
 */

public class AncientDragonDinocrowd : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard()
			   && VanguardIs("Tachikaze")
			   && NumUnits(delegate(Card c) { return c.name.Contains("Ancient Dragon"); }) > 0)
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
			SelectUnit("Choose one of your rear-guards with \"Ancient Dragon\" in its card name.", 1, true,
			delegate {
				RetireUnit(Unit);
			},
			delegate {
				return Unit.name.Contains("Ancient Dragon");
			},
			delegate {
				IncreasePowerByBattle(OwnerCard, 5000);
			});
		});
	}
}
