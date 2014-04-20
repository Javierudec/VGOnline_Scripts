using UnityEngine;
using System.Collections;

public class TwinHolyBeastBlackLion : UnitObject {
	public override void Cont ()
	{
		if(IsPlayerTurn()
		   && NumUnits(delegate(Card c) { return c.BelongsToClan("Gold Paladin"); }) >= 4)
		{
			AddContPower(3000);
		}
	}
}
