using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Choose three of your rear-guards with "Ancient Dragon" in its card 
 * name, and retire them] When this unit attacks a vanguard, you may pay the 
 * cost. If you do, this unit gets [Power]+10000/[Critical]+1 until end of that
 * battle.
 * 
 * [ACT](VC):[Counter Blast (2) - Cards with "Ancient Dragon" in its card name] 
 * This unit gets [Power]+5000 until end of turn.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this 
 * unit cannot attack)
 */

public class AncientDragonTyrannolegend : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && LimitBreak(4)
			   && GetDefensor().IsVanguard()
			   && NumUnits (delegate(Card c) { return c.name.Contains("Ancient Dragon"); }) >= 3)
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Active ()
	{
		if(!GetBool(1))
		{
			StartEffect();
		}

		ShowAndDelay();
	}

	public override int Act ()
	{
		if(VC()
		   && CB (2, delegate(Card c) { return c.name.Contains("Ancient Dragon"); }))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(!GetBool(1))
			{
				CounterBlast(2,
				delegate {
					IncreasePowerByTurn(OwnerCard, 5000);
					EndEffect();
				},
				delegate(Card c) {
					return c.name.Contains("Ancient Dragon");
				});
			}
			else
			{
				UnsetBool(1);
				SelectUnit("Choose three of your rear-guards with \"Ancient Dragon\" in its card name.", 3, true,
				delegate {
					RetireUnit(Unit);
				},
				delegate {
					return Unit.name.Contains("Ancient Dragon");
				},
				delegate {
					IncreasePowerByBattle(OwnerCard, 10000);
					IncreaseCriticalByBattle(OwnerCard, 1);
				});
			}
		});
	}
}
