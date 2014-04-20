using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):When this unit attacks, if you have three or more other 
 * rear-guards with "Liberator" in its card name, this unit gets [Power]+3000 
 * until end of that battle.
 */

public class ZoigalLiberator : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(NumUnits(delegate(Card c) { return c.name.Contains("Liberator") && c != OwnerCard; }) >= 3)
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
