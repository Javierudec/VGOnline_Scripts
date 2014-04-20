using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC): During your battle phase, when your «Nova Grappler» 
 * becomes [Stand], if you have a vanguard with "Asura" in its card name, this 
 * unit gets [Power]+3000 until end of turn.
 */

public class DaredevilSamurai : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Stand_NotMe || cs == CardState.Stand)
		{
			if(ownerEffect.BelongsToClan("Nova Grappler") && GetVanguard().name.Contains("Asura"))
			{
				IncreasePowerByTurn(OwnerCard, 3000);	
			}
		}
	}
}
