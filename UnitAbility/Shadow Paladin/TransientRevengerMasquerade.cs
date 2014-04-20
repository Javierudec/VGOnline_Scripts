using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit attacks, if you have a vanguard with 
 * "Revenger" in its card name, this unit gets [Power]+3000 until end of 
 * battle.
 */

public class TransientRevengerMasquerade : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC() && GetVanguard().name.Contains("Revenger"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
		}
	}
}
