using UnityEngine;
using System.Collections;

public class DemonChariotOfTheWitchingHour : UnitObject {
	public override void Cont()
	{
		if(IsPlayerTurn())
		{
			AddContPower(2000 * Game.field.CountSoul(delegate (Card c) { return c.cardID == CardIdentifier.DEMON_CHARIOT_OF_THE_WITCHING_HOUR; }));
		}
	}
}
