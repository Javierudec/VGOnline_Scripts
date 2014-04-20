using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit's attack hits a vanguard, choose 
 * one of your «Aqua Force» , and that unit gets [Power]+3000 
 * until end of turn.
 */

public class MobileBattleshipArchelon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(RC()
			   && GetDefensor().IsVanguard()
			   && NumUnits(delegate(Card c) { return c.BelongsToClan("Aqua Force"); }, true) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your \"Aqua Force\".", 1, true,
			delegate {
				IncreasePowerByBattle(Unit, 3000);
			},
			delegate {
				return Unit.BelongsToClan("Aqua Force");
			},
			delegate {

			}, true);
		});
	}
}
