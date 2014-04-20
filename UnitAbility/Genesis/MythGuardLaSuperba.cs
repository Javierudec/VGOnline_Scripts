using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC): When this unit attacks a vanguard, if 
 * you have a «Genesis» vanguard, this unit gets [Power]+2000 until end of
 * that battle.
 */

public class MythGuardLaSuperba : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard()
			   && VanguardIs("Genesis"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}
}
