using UnityEngine;
using System.Collections;

/*
 * [CONT](RC):If you have a unit named "Drive Quartet, Shuplu" on 
 * your (RC), this unit gets [Power]+3000.
 */

public class DriveQuartetFlows : UnitObject {
	public override void Cont ()
	{
		if(RC ()
		   && NumUnits(delegate(Card c) { return c.cardID == CardIdentifier.DRIVE_QUARTET__SHUPLU; }) > 0)
		{
			AddContPower(3000);
		}
	}	
}
