using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Counter Blast (2)] When an attack hits a vanguard during the 
 * battle that this unit boosted a «Genesis», you may pay the cost. If you do, 
 * Soul Charge (3).
 */

public class BattleMaidenTatsuhime : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(RC() && c != null && c == GetAttacker() && c.BelongsToClan("Genesis") && GetDefensor().IsVanguard() && CB(2) && GetDeck().Size() >= 3)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SoulCharge(3);
			});
		});
		
		SoulChargeUpdate(delegate {
			EndEffect();	
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
