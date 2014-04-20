using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit attacks, if you have a vanguard with 
 * "Ancient Dragon" in its card name, this unit gets [Power]+3000 
 * until end of that battle.
 */

public class AncientDragonTriplasma : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC ()
			   && GetVanguard().name.Contains("Ancient Dragon"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
