using UnityEngine;
using System.Collections;

/*
 * [CONT](RC):If you have a unit named "Drive Quartet, Bubblin" on your
 * (RC), this unit gets [Power]+3000.
 */

public class DriveQuartetShuplu : UnitObject {
	public override void Cont ()
	{
		if(RC ()
		   && NumUnits(delegate(Card c) { return c.cardID == CardIdentifier.DRIVE_QUARTET__BUBBLIN; }) > 0)
		{
			AddContPower(3000);
		}
	}
}
