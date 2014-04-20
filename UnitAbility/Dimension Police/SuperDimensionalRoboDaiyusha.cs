using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC):At the beginning of your attack step, if this unit’s [Power] is 
 * 14000 or greater, this unit gets [Critical]+1 until end of that battle.
 */

public class SuperDimensionalRoboDaiyusha : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC() && OwnerCard.GetPower() >= 14000)
			{
				IncreaseCriticalByBattle(OwnerCard, 1);	
			}
		}
	}
}
