using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC): When this unit attacks, if the number of rear-guards your 
 * opponent has is two or less, this unit gets [Power]+3000 until end of that 
 * battle.
 */

public class LizardSoldierRyoshin : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(NumEnemyUnits(delegate(Card c) { return true; }) <= 2)
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
