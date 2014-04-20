using UnityEngine;
using System.Collections;

/*
 * [CONT](VC/RC): Restraint (This unit cannot attack.)
 * 
 * [AUTO](VC/RC):During your main phase, when an opponent's rear-guard is 
 * put into the drop zone, this unit loses "Restraint" until end of turn.
 * 
 * [AUTO](VC):When this unit is boosted by a «Kagero», this unit gets 
 * [Power]+5000 until end of that battle.
 */

public class GenieSoldat : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(CurrentPhaseIs(GamePhase.MAIN_PHASE))
			{
				OwnerCard.RemoveRestraint();	
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			Card tmp = OwnerCard.IsBoostedBy;
			if(VC() && tmp != null && tmp.BelongsToClan("Kagero"))
			{
				IncreasePowerByBattle(OwnerCard, 5000);	
			}
		}
	}
}
