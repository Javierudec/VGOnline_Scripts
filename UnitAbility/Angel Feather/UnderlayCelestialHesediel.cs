using UnityEngine;
using System.Collections;

/*
 * [CONT](VC/RC):During your turn, if you have a face up card 
 * named "Solidify Celestial, Zerachiel" in your damage zone, 
 * this unit gets [Power]+3000.
 */

public class UnderlayCelestialHesediel : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(IsPlayerTurn()
		   && NumUnitsDamage(delegate(Card c) { return c.IsFaceup() && c.cardID == CardIdentifier.SOLIDIFY_CELESTIAL__ZERACHIEL; }) > 0)
		{
			power += 3000;
		}
		SetPower(power);
	}
}
