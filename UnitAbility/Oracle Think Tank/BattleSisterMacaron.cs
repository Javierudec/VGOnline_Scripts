using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit attacks, if you have a vanguard with "Battle 
 * Sister" in its card name, this unit gets [Power]+3000 until end of that 
 * battle.
 */

public class BattleSisterMacaron : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC () && GetVanguard().name.Contains("Battle Sister"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			ConfirmAttack();	
		}
	}
}
