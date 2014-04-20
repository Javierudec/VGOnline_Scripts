using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Soul Blast (3)] When this unit attacks a vanguard, you may pay the 
 * cost. If you do, this unit gets [Power]+5000/[Critical]+1 until end of that 
 * battle.
 * 
 * [AUTO](VC):When this unit attacks a vanguard, this unit gets [Power]+3000 
 * until end of that battle.
 */

public class BattleMaidenMizuha : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC() && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			if(VC() && LimitBreak(4) && GetDefensor().IsVanguard() && CanSoulBlast(3))
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
			SoulBlast(3);	
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 5000);
			IncreaseCriticalByBattle(OwnerCard, 1);
			EndEffect();
		});
	}
}
