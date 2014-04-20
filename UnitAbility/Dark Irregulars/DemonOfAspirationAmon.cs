using UnityEngine;
using System.Collections;

/*
 * [CONT](VC/RC):During your turn, if the number of «Dark Irregulars» 
 * in your soul is six or more, this unit gets [Power]+3000.
 */

public class DemonOfAspirationAmon : UnitObject {
	public override void Cont ()
	{
		if(IsPlayerTurn()
		   && NumUnitsInSoul(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) >= 6)
		{
			AddContPower(3000);
		}
	}
}
