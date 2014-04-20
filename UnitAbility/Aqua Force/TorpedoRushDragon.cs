using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC): When this unit boosts an «Aqua Force», if you have an 
 * «Aqua Force» vanguard, if the number of battles during this turn 
 * is four or more, the boosted unit gets [Power]+3000 until end of that battle.
 */

public class TorpedoRushDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && tmp.BelongsToClan("Aqua Force")
			   && VanguardIs("Aqua Force")
			   && Game.numBattle >= 4)
			{
				IncreasePowerByBattle(tmp, 3000);
			}
		}
	}
}
