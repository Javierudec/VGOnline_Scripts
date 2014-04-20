using UnityEngine;
using System.Collections;

public class HadesCarriageOfTheWitchingHour : UnitObject {
	public override void Cont()
	{
		if(IsPlayerTurn())
		{
			AddContPower(Game.field.CountSoul(delegate(Card c) { return c.cardID == CardIdentifier.HADES_CARRIAGE_OF_THE_WITCHING_HOUR; }) * 2000);
		}
	}
}
