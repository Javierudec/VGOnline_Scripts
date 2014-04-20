using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):During your turn, if you have another 
 * unit named "Stealth Beast, Gigantoad" on your 
 * (RC), this unit gets [Power]+3000.
 * 
 * [CONT](RC):During your turn, if you have another unit named 
 * "Stealth Beast, Gigantoad" on your (RC), this unit gets [Power]+1000.
 */

public class StealthBeastGigantoad : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsPlayerTurn()
		   && NumUnits(delegate(Card c) { return c.cardID == CardIdentifier.STEALTH_BEAST__GIGANTOAD && c != OwnerCard; }) > 0)
		{
			AddContPower(3000);
		}

		if(RC ()
		   && IsPlayerTurn()
		   && NumUnits(delegate(Card c) { return c.cardID == CardIdentifier.STEALTH_BEAST__GIGANTOAD && c != OwnerCard; }) > 0)
		{
			AddContPower(1000);
		}
	}
}
