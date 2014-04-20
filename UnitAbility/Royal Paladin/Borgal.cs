using UnityEngine;
using System.Collections;

/*
 * [CONT](VC/RC):During your turn, if the number of «Royal Paladin»
 * in your soul is six or more, this unit gets [Power]+3000.
 */

public class Borgal : UnitObject {
	public override void Cont ()
	{
		if(IsPlayerTurn()
		   && NumUnitsInSoul(delegate(Card c) { return c.BelongsToClan("Royal Paladin"); }) > 0)
		{
			SetPower(3000);
		}
	}
}
