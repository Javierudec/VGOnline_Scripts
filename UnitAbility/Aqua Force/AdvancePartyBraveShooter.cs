using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, 
 * you may call this unit to (RC))
 * 
 * [AUTO](RC):When this unit boosts, if you have an «Aqua Force» 
 * vanguard, and if the number of [Rest] rear-guards you have is 
 * two or less, the boosted unit gets [Power]+3000 until end of that battle.
 */

public class AdvancePartyBraveShooter : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Aqua Force");
		}
		else if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && VanguardIs("Aqua Force")
			   && NumUnits(delegate(Card c) { return !c.IsStand(); }) <= 2)
			{
				IncreasePowerByBattle(tmp, 3000);
			}
		}
	}

	public override void Active ()
	{
		Forerunner_Active();
	}

	public override void Update ()
	{
		Forerunner_Update();
	}
}
