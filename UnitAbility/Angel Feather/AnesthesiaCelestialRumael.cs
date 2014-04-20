using UnityEngine;
using System.Collections;

public class AnesthesiaCelestialRumael : UnitObject {
	public override void Cont ()
	{
		if(IsPlayerTurn())
		{
			AddContPower(2000 * NumUnitsDamage(delegate(Card c) { return c.cardID == CardIdentifier.ANESTHESIA_CELESTIAL__RUMAEL; }));
		}
	}
}
