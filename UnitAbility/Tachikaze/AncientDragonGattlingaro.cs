using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Choose another of your rear-guards with "Ancient Dragon" 
 * in its card name, and retire it] When this unit attacks a vanguard, if
 * you have a «Tachikaze» vanguard, you may pay the cost. If you do, this 
 * unit gets [Power]+5000 until end of that battle.
 */

public class AncientDragonGattlingaro : UnitObject {
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard()
			   && NumUnits(delegate(Card c) { return c != OwnerCard && c.name.Contains("Ancient Dragon"); }) > 0
			   && VanguardIs("Tachikaze"))
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active()
	{
		ShowAndDelay();
	}

	public override void Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your rear-guards with \"Ancient Dragon\" in its card name.", 1, true,
			delegate {
				RetireUnit(Unit);
			},
			delegate {
				return Unit != OwnerCard && Unit.name.Contains("Ancient Dragon");
			},
			delegate {
				IncreasePowerByBattle(OwnerCard, 5000);
			});
		});
	}
}
