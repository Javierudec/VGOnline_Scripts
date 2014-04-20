using UnityEngine;
using System.Collections;

/*
 * AUTO: When this unit intercepts, if you have a 《Megacolony》 
 * vanguard, this unit gets Shield +5000.
 */

public class IronFistMutantRolyPoly : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Intercept)
		{
			if(VanguardIs(OwnerCard.clan))
			{
				AddPowerToGuardZone(5000);			
			}
		}
	}
}
