using UnityEngine;
using System.Collections;

public class StarvaderChaosBeatDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && tmp.cardID == CardIdentifier.STAR_VADER__CHAOS_BREAKER_DRAGON
			   && NumEnemyUnits(delegate(Card c) { return c.IsLocked(); }, true, true) > 0)
			{
				IncreasePowerByBattle(tmp, 5000);
			}
		}
	}
}
