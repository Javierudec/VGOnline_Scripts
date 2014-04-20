using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC): When this unit is boosted by a «Bermuda Triangle», 
 * this unit gets [Power]+2000 until end of that battle.
 */

public class PRISMRomanceEtolle : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.IsBoosted)
		{
			Card tmp = OwnerCard.IsBoostedBy;
			if(tmp != null && tmp.BelongsToClan("Bermuda Triangle"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
}
