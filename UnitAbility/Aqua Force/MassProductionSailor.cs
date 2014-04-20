using UnityEngine;
using System.Collections;

/*
 * [CONT]: You may have up to sixteen cards named "Mass Production Sailor" in a deck.
 * 
 * [CONT](RC): During your turn, this unit gets [Power]+1000 for each other unit named 
 * "Mass Production Sailor" on your (VC) or (RC).
 */

public class MassProductionSailor : UnitObject {
	public override void Cont()
	{
		if(RC()
		   && IsPlayerTurn())
		{
			AddContPower(1000 * NumUnits(delegate(Card c) { return c.cardID == CardIdentifier.MASS_PRODUCTION_SAILOR; }, true));
		}
	}
}
