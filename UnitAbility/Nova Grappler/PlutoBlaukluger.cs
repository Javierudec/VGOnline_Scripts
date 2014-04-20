using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):When this unit attacks a vanguard, this unit gets [Power]+5000 until 
 * end of that battle.
 * 
 * [AUTO](VC):[Counter Blast (3)] When this unit's attack hits a vanguard, you 
 * may pay the cost. If you do, choose up to two of your «Nova Grappler» 
 * rear-guards, and [Stand] them.
 */

public class PlutoBlaukluger : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC() && LimitBreak(4) && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 5000);	
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(VC () && CB (3) && GetDefensor().IsVanguard() && NumUnits(delegate(Card c) { return !c.IsStand() && c.BelongsToClan("Nova Grappler"); }) > 0)
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
			CounterBlast(3,
			delegate {
				int num = min (2, NumUnits(delegate(Card c) { return !c.IsStand() && c.BelongsToClan("Nova Grappler"); }));
				SelectUnit("Choose up to two of your \"Nova Grappler\" rear-guards.", num, true,
				delegate {
					StandUnit(Unit);
				},
				delegate {
					return !Unit.IsStand() && Unit.BelongsToClan("Nova Grappler");
				},
				delegate {
					
				});
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectUnit_Pointer(true);
	}
}

