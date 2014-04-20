using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC): When this unit attacks a vanguard, if the battle opponent's 
 * [Power] is 12000 or greater, this unit gets [Power]+10000 until end of that 
 * battle.
 * 
 * [AUTO](RC): When this unit attacks a vanguard, if you have a «Great 
 * Nature» vanguard, this unit gets [Power]+2000 until end of that battle.
 */

public class UnrivaledBrushWielderPonga : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && GetDefensor().IsVanguard() && GetVanguard().GetPower() >= 12000)
			{
				IncreasePowerByBattle(OwnerCard, 10000);	
			}
			
			if(RC () && GetDefensor().IsVanguard() && VanguardIs("Great Nature"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
			
			ConfirmAttack();	
		}
	}
}
