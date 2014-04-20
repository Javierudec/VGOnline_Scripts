using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When your grade 3 «Bermuda Triangle» is placed on 
 * (VC), this unit gets [Power]+10000 until the end of turn.
 */

public class DancingFanPrincessMinato : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride_NotMe)
		{
			if(ownerEffect.grade == 3 && ownerEffect.BelongsToClan("Bermuda Triangle") && RC ())
			{
				IncreasePowerByTurn(OwnerCard, 10000);
			}
		}
	}
}
