using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):When this unit attacks a vanguard, if you 
 * have a «Gold Paladin» vanguard, this unit gets 
 * [Power]+2000 until end of that battle.
 */

public class GigantechDestroyer : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard() && VanguardIs(OwnerCard.clan))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
			ConfirmAttack ();
		}
	}
}
