using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit attacks, if you have an «Oracle Think 
 * Tank» vanguard, and you do not have any cards in your soul, this unit 
 * gets [Power]+3000 until end of that battle.
 */

public class BattleSisterOmelet : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VanguardIs("Oracle Think Tank") && CardsInSoul() == 0)
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			ConfirmAttack();	
		}
	}
}
