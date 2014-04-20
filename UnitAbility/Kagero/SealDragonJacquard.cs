using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC): When this unit attacks, if you have a vanguard with 
 * "Seal Dragon" in its card name, this unit gets [Power]+3000 until
 * end of the battle.
 */

public class SealDragonJacquard : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC ()
			   && GetVanguard().name.Contains("Seal Dragon"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}
}
