using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit boosts a «Gold Paladin» vanguard, if you have 
 * three or more other rear-guards with "Liberator" in its card name, the 
 * boosted unit gets [Power]+4000 until end of that battle.
 */

public class FutureLiberatorLlew : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC() && tmp != null && tmp.BelongsToClan("Gold Paladin") && tmp.IsVanguard() && NumUnits(delegate(Card c) { return c != OwnerCard && c.name.Contains("Liberator"); }) > 0)
			{
				IncreasePowerByBattle(tmp, 4000);	
			}
		}
	}
}
