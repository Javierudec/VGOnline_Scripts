using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC): When this unit's drive check reveals a Grade 3 
 * 《Royal Paladin》, this Unit gets [Power]+5000 until end of that battle.
 */

public class KnightOfTheHarpTristan : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC()
			   && Game.DriveCard.BelongsToClan("Royal Paladin")
			   && Game.DriveCard.grade == 3)
			{
				IncreasePowerByBattle(OwnerCard, 5000);
			}
		}
	}
}
