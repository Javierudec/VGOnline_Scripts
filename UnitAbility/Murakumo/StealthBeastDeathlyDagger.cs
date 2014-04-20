using UnityEngine;
using System.Collections;

public class StealthBeastDeathlyDagger : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && tmp.BelongsToClan("Murakumo")
			   && NumUnits(delegate(Card c) { return c.cardID == tmp.cardID; }) >= 2)
			{
				IncreasePowerByBattle(tmp, 3000);
			}
		}
	}
}
