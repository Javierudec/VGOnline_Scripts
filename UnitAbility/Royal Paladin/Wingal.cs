using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit boosts a card named "Blaster Blade", 
 * the boosted unit gets [Power]+4000 until end of that battle.
 */

public class Wingal : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && tmp.cardID == CardIdentifier.BLASTER_BLADE)
			{
				IncreasePowerByBattle(tmp, 4000);
			}
		}
	}
}
