using UnityEngine;
using System.Collections;

public class OperationCelestialArmen : UnitObject {
	public override void Cont ()
	{
		if(IsPlayerTurn())
		{
			AddContPower(2000 * NumUnitsDamage(delegate(Card c) { return c.IsFaceup() && c.cardID == CardIdentifier.OPERATION_CELESTIAL__ARMEN; }));
		}
	}
}
