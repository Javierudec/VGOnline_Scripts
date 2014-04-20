using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC): When this unit boosts a unit named "Transcendence Dragon, Dragonic Nouvelle Vague", 
 * the boosted unit gets [Power]+3000 until end of 
 * battle.
 */

public class DragonKnightAshgar : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC() && tmp != null && tmp.cardID == CardIdentifier.TRANSCENDENCE_DRAGON__DRAGONIC_NOUVELLE_VAGUE)
			{
				IncreasePowerByBattle(tmp, 3000);
			}
		}
	}
}
