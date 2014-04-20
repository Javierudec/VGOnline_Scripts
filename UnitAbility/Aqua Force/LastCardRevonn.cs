using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or 
 * more damage):[Counter Blast (1)] When this unit attacks a vanguard, 
 * if the number of [Rest] «Aqua Force» in your front row is three, you 
 * may pay the cost. If you do, this unit gets [Power]+3000/[Critical]+1 
 * until end of that battle.
 * 
 * [ACT](VC):[Counter Blast (1)] This unit gets [Power]+2000 until end of turn.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class LastCardRevonn : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC()
			   && LimitBreak(4)
			   && GetDefensor().IsVanguard()
			   && CB(1)
			   && NumUnits(delegate(Card c) { return IsInFrontRow(c) && c.BelongsToClan("Aqua Force") && !c.IsStand(); }, true) == 3)
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active ()
	{
		if(GetBool(1))
		{
			StartEffect();
		}

		ShowAndDelay();
	}

	public override int Act ()
	{
		if(VC ()
		   && CB (1))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				if(GetBool(1))
				{
					UnsetBool(1);
					IncreasePowerByTurn(OwnerCard, 2000);
				}
				else
				{
					IncreasePowerByBattle(OwnerCard, 3000);
					IncreaseCriticalByBattle(OwnerCard, 1);
				}
				EndEffect();
			});
		});
	}
}
