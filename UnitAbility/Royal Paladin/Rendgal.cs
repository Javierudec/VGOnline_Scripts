using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is placed on (RC) from your deck, if you have a 
 * «Royal Paladin» vanguard, this unit gets [Power]+3000 until end of turn.
 */

public class Rendgal : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.CallFromDeck)
		{
			if(VanguardIs("Royal Paladin"))
			{
				IncreasePowerByTurn(OwnerCard, 3000);	
			}
		}
	}
}
