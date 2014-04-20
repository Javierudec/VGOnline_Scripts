using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):When this unit attacks, if you have a «Aqua Force» vanguard 
 * or rear-guard with Limit Break 4, this unit gets [Power]+3000 until end 
 * of that battle.
 */

public class TitanOfTheBeamRifle : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(NumUnits (delegate(Card c) { return c.BelongsToClan("Aqua Force") && c.bHasLimitBreak4; }, true) > 0)
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
