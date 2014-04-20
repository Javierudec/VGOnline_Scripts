using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit boosts a «Neo Nectar», if you have a «Neo 
 * Nectar» vanguard, and if your deck has been shuffled by your card's effect 
 * during that turn, the boosted unit gets [Power]+3000 until end of that battle.
 */

public class DandelionMusketeerMirkka : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			
			if(RC() && tmp != null && tmp.BelongsToClan("Neo Nectar") && VanguardIs("Neo Nectar") && Game.bDeckHasBeenShuffledThisTurn)
			{
				IncreasePowerByBattle(tmp, 3000);
			}
		}
	}
}
