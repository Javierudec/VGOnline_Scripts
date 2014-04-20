using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit attacks, if you have a vanguard with "Star-vader" 
 * in its card name, this unit gets [Power]+3000 until end of that battle.
 */

public class UnrivaledStarvaderRadon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC() && GetVanguard().name.Contains("Star-vader"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
		}
	}
}
