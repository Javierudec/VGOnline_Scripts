using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC): When this unit's drive check reveals a grade 3 
 * 《Royal Paladin》, this unit gets [Power] +5000 until end of that battle.
 */

public class CrimsonButterflyBrigitte : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC()
			   && Game.DriveCard.grade == 3
			   && Game.DriveCard.BelongsToClan("Royal Paladin"))
			{
				IncreasePowerByBattle(OwnerCard, 5000);
			}
		}
	}
}
