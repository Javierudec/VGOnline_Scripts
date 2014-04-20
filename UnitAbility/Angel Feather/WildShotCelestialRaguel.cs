using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit attacks, if you have a vanguard with 
 * "Celestial" in its card name, this unit gets [Power]+3000.
 */

public class WildShotCelestialRaguel : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC ()
			   && GetVanguard().name.Contains("Celestial"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
