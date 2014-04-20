using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):When this unit attacks a vanguard, this unit gets [Power]+5000 until 
 * end of that battle.
 * 
 * [AUTO](RC):When this unit attacks a vanguard, if you have a «Gold 
 * Paladin» vanguard, this unit gets [Power]+2000 until end of that battle.
 */

public class VenomousBreathDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && LimitBreak(4) && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 5000);	
			}
			
			if(RC() && GetDefensor().IsVanguard() && VanguardIs("Narukami"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
}
