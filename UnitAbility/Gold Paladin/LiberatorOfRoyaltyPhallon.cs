using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit attacks, if you have a vanguard with "Liberator" in 
 * its card name, this unit gets [Power]+3000 until end of that battle.
 */

public class LiberatorOfRoyaltyPhallon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC() && GetVanguard().name.Contains("Liberator"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
		}
	}
}
