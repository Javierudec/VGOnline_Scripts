using UnityEngine;
using System.Collections;

/*
 * [CONT](VC/RC): During your turn, this unit gets [Power] +2000 for
 * each card named "Demon Bike of the Witching Hour" in your soul.
 */

public class DemonBikeOfTheWitchingHour : UnitObject {
	public override void Cont ()
	{
		if(IsPlayerTurn())
		{
			AddContPower(2000 * NumUnitsInSoul(delegate(Card c) { return c.cardID == CardIdentifier.DEMON_BIKE_OF_THE_WITCHING_HOUR; }));
		}
	}	
}
