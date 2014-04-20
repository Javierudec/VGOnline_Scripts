using UnityEngine;
using System.Collections;

/*
 * [CONT]: Sentinel (You may only have up to four cards with "[CONT]: 
 * Sentinel" in a deck)
 * [AUTO]:[Choose an «Aqua Force» from your hand, and discard it] When 
 * this unit is placed on (GC), you may pay the cost. If you do, choose one of 
 * your «Aqua Force» that is being attacked, and that unit cannot be hit until 
 * end of that battle.
 */

public class EmeraldShieldPaschal : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.UsedToGuard)
		{
			if(VanguardIs(OwnerCard.clan) && Game.playerHand.Size() > 0 && !Game.bDoPerfectGuardPerBattle)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectInHand(1, true, 
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return true;
			},
			delegate {
				PerfectGuard();
			}, "Choose one card from your hand.");
		});
	}
	
	public override void Pointer ()
	{
		SelectInHand_Pointer();
	}
}
