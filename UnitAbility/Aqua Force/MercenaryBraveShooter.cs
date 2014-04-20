using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit attacks, if you have an «Aqua Force» vanguard, 
 * and if the number of [Rest] rear-guards you have is two or less, this 
 * unit gets [Power]+3000 until end of that battle.
 */

public class MercenaryBraveShooter : UnitObject {
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Attacking)
		{
			if(RC()
			   && VanguardIs("Aqua Force")
			   && NumUnits(delegate(Card c) { return !c.IsStand(); }) <= 2)
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
