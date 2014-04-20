using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):When this unit attacks a vanguard, if you 
 * have a «Megacolony» vanguard, this unit gets 
 * [Power]+2000 until end of that battle.
 */

public class CuoreMagus : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC() && GetVanguard().name.Contains("Magus"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack ();
		}
	}
}
