using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When a «Dimension Police» rides this unit, choose your vanguard, 
 * and that unit gets [Power]+5000 until end of turn.
 */

public class DimensionalRoboKaizard : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Dimension Police"))
			{
				IncreasePowerByTurn(GetVanguard(), 5000);	
			}
		}
	}
}
