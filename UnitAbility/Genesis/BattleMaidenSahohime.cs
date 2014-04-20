using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (1)] When this unit's attack hits a vanguard, 
 * if you have a «Genesis» vanguard, you may pay the cost. If you do, Soul 
 * Charge (3).
 */

public class BattleMaidenSahohime : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() && CB(1) && VanguardIs("Genesis") && GetDeck().Size() >= 3)
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
			CounterBlast(1,
			delegate {
				SoulCharge(3);
			});
		});
		
		SoulChargeUpdate(delegate {
			EndEffect();	
		});
	}
	
	public override void Pointer()
	{
		CounterBlast_Pointer();	
	}
}
