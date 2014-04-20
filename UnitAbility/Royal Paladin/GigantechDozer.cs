using UnityEngine;
using System.Collections;

public class GigantechDozer : UnitObject {
	public override void Cont()
	{
		if(IsPlayerTurn() && Game.field.GetUnitsSoulWithClanName("Royal Paladin") >= 6)
		{
			AddContPower(3000);
		}
	}
}
