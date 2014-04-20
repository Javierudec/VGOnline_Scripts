using UnityEngine;
using System.Collections;

public class TurquoiseBeastTamer : UnitObject {
	public override void Cont()
	{
		if(IsPlayerTurn() && Game.field.GetSoulByID(CardIdentifier.CRIMSON_BEAST_TAMER) != null)
		{
			AddContPower(3000);	
		}
	}
}
