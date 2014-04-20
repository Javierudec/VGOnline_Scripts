using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit boosts a «Narukami» vanguard, if the 
 * number of cards in your opponent's damage zone is three or more, 
 * the boosted unit gets [Power]+4000 until end of that battle.
 */

public class EradicatorOfFireKohkaiji : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC() && tmp != null && tmp.BelongsToClan("Narukami") && Game.enemyField.GetDamage() >= 3)
			{
				IncreasePowerByBattle(tmp, 4000);	
			}
		}
	}
}
