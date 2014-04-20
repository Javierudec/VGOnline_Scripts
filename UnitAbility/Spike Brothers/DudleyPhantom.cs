using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit boosts a «Spike Brothers», 
 * the boosted unit gets [Power]+4000 until end of that 
 * battle, and at the beginning of the close step of that 
 * battle, put this unit on the bottom of your deck
 */

public class DudleyPhantom : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && tmp.BelongsToClan("Spike Brothers"))
			{
				IncreasePowerByBattle(tmp, 4000);
				SetBool(1);
			}
		}
		else if(cs == CardState.EndBattle)
		{
			UnsetBool(1);
			FromFieldToDeck(OwnerCard, true);
		}
	}
}
