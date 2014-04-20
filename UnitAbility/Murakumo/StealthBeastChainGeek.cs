using UnityEngine;
using System.Collections;

public class StealthBeastChainGeek : UnitObject {
	public override void Cont ()
	{
		if(IsPlayerTurn()
		   && NumUnits (delegate(Card c) { return c.BelongsToClan("Murakumo"); }) >= 4)
		{
			AddContPower(3000);
		}
	}
}
