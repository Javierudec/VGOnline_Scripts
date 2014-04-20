using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, 
 * you may call this unit to (RC))
 * 
 * [AUTO](RC):When a unit in the same column as this unit with "Beast Deity" 
 * in its card name becomes [Stand], [Stand] this unit.
 */

public class BeastDeityRiotHorn : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Nova Grappler");
		}
		else if(cs == CardState.Stand_NotMe)
		{
			if(RC () && GetSameColum(OwnerCard.pos) == ownerEffect && ownerEffect.name.Contains("Beast Deity"))
			{
				StandUnit(OwnerCard);
			}
		}
	}

	public override void Active ()
	{
		Forerunner_Active();
	}

	public override void Update ()
	{
		Forerunner_Update();
	}
}
