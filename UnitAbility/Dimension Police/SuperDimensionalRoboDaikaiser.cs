using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or 
 * more damage):[Counter Blast (1)] When a «Dimension Police» rides this unit, you 
 * may pay the cost. If you do, choose your vanguard, that unit gets 
 * [Power]+10000/[Critical]+1 and "[AUTO](VC):When this unit's drive check 
 * reveals a grade 3 «Dimension Police», choose one of your opponent's 
 * guardians, retire it, and any effect with "Cannot be hit" of that retired unit is 
 * negated." until end of turn.
 * 
 * [AUTO](VC):When this unit is boosted by a «Dimension Police», this unit 
 * gets [Power]+2000 until end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class SuperDimensionalRoboDaikaiser : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(LimitBreak(4) && VanguardIs("Dimension Police") && CB(1))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			Card tmp = OwnerCard.IsBoostedBy;
			if(VC () && tmp != null && tmp.BelongsToClan("Dimension Police"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
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
			CounterBlast(1,
			delegate {
				IncreasePowerAndCriticalByTurn(GetVanguard(), 10000, 1);
				GetVanguard().unitAbilities.AddUnitObject(new DaikaiserExternEffect());
				EndEffect();
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}

public class DaikaiserExternEffect : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(Game.DriveCard.BelongsToClan("Dimension Police") && Game.DriveCard.grade == 3 && NumGuardians() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectInGuard("Choose one of your opponent's guardians.", 1, true,
			delegate {
				RetireEnemyGuardian(Guardian);
			},
			delegate {
				return true;
			},
			delegate {
				
			});
		});
	}
	
	public override void Pointer()
	{
		SelectInGuard_Pointer();	
	}
}