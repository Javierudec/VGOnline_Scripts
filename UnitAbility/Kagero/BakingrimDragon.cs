using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When your grade 3 «Kagerō» is placed on (VC), this unit gets 
 * [Power]+10000 until end of turn.
 */

public class BakingrimDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride_NotMe)
		{
			if(GetVanguard().grade == 3 && VanguardIs("Kagero"))
			{
				IncreasePowerByTurn(OwnerCard, 10000);	
			}
		}
	}
}
