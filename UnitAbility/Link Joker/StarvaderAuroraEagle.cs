using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit boosts a «Link Joker» vanguard, if the number 
 * of rear-guards you have is more than your opponent's, the boosted unit gets 
 * [Power]+4000 until end of that battle.
 */

public class StarvaderAuroraEagle : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC() && tmp != null && tmp.BelongsToClan("Link Joker") && tmp.IsVanguard())
			{
				if(NumUnits(delegate(Card c) { return true; }) > NumEnemyUnits(delegate(Card c) { return true; }))
				{
					IncreasePowerByBattle(tmp, 4000);	
				}
			}
		}
	}
}
