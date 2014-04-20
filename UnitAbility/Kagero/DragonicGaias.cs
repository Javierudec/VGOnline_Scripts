using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Soul Blast (2) & [Rest] this unit] When your «Kagerō» normal 
 * unit in the same column as this unit attacks, you may pay the cost. If you do, 
 * that unit gets [Critical]+1 until end of that battle.
 */

public class DragonicGaias : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking_NotMe)
		{
			if(RC() && CanSoulBlast(2) && OwnerCard.IsStand() && ownerEffect == GetSameColum(OwnerCard.pos) && ownerEffect.BelongsToClan("Kagero") && ownerEffect.GetTriggerType() == TriggerIcon.NONE)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulBlast(2);	
		});
		
		SoulBlastUpdate(delegate {
			RestUnit(OwnerCard);
			IncreaseCriticalByBattle(GetSameColum(OwnerCard.pos), 1);
			EndEffect();
		});
	}
}
