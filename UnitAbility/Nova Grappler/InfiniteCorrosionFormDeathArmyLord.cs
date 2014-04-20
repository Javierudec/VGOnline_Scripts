using UnityEngine;
using System.Collections;

/*
 * [ACT](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (2)] [Stand] all of your «Nova Grappler» rear-
 * guards. If four or more units [Stand] this way, this unit gets [Critical]+1 
 * until end of turn. This ability cannot be used for the rest of that turn.
 * 
 * [ACT](VC):[Choose two of your rear-guards with "Death Army" in its 
 * card name, and [Rest] them] This unit gets [Power]+5000 until end of turn.
 */

public class InfiniteCorrosionFormDeathArmyLord : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(3);
		}
	}
	
	public override int Act ()
	{
		int numActive = 0;
		if(VC () && LimitBreak(4) && CB (2) && !GetBool(3))
		{
			numActive++;	
		}
		
		if(VC() && NumUnits(delegate(Card c) { return c.name.Contains("Death Army") && c.IsStand(); }) >= 2)
		{
			numActive++;	
		}
		
		return numActive;
	}
	
	public override void Active (int idAbility)
	{
		StartEffect();
		ShowAndDelay();
		SetBool(idAbility);
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			bool bFirstAbility = true;
			if(GetBool(2))
			{
				UnsetBool(2);
				bFirstAbility = false;
			}
			else
			{
				bFirstAbility = false;
				if(VC () && LimitBreak(4) && CB (2) && !GetBool(3))
				{	
					bFirstAbility = true;
				}	
			}
			
			if(!bFirstAbility)
			{
				SelectUnit("Choose two of your rear-guards with \"Death Army\" in its card name.", 2, true,
				delegate {
					RestUnit(Unit);
				},
				delegate {
					return Unit.name.Contains("Death Army") && Unit.IsStand();
				},
				delegate {
					IncreasePowerByTurn(OwnerCard, 5000);
				});
			}
			else
			{
				CounterBlast(2,
				delegate {
					int numStandUnits = 0;
					ForEachUnitOnField(delegate(Card c) {
						if(!c.IsVanguard() && c.BelongsToClan("Nova Grappler") && !c.IsStand())
						{
							numStandUnits++;
							StandUnit(c);
						}
					});
					if(numStandUnits >= 4)
					{
						IncreasePowerAndCriticalByTurn(OwnerCard, 0, 1);	
					}
					SetBool(3);
					EndEffect();
				});
			}
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectUnit_Pointer();
	}
}
