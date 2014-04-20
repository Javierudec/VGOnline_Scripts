using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or 
 * more damage):When this unit attacks a vanguard, you may choose up 
 * to three cards with "PR♥ISM" in its card name from your hand, and call 
 * them to separate open (RC). If you called three cards, this unit gets 
 * [Power]+10000/[Critical]+1 until end of that battle.
 * 
 * [ACT](VC):[Counter Blast (1)-card with "PR♥ISM" in its card name] 
 * Choose one of your rear-guards with "PR♥ISM" in its card name, and 
 * return it to your hand.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this 
 * unit, this unit cannot attack)
 */

public class PRISMPromiseLabrador : UnitObject {
	int numUnitsToCall = 0;
	int unitsCalled = 0;
	bool bCall = false;
	int totalUnits = 0;
	bool bEndSkill = false;
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && LimitBreak(4) && GetDefensor().IsVanguard())
			{
				SetBool(1);
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}
	
	public override int Act ()
	{
		if(VC () && CB (1, delegate(Card c) { return c.name.Contains("PRISM"); }) && NumUnits(delegate(Card c) { return c.name.Contains("PRISM"); }) > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active ()
	{
		if(!GetBool(1))
		{
			StartEffect();
			ShowAndDelay();
		}
		else
		{
			ShowAndDelay();
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				int numOpen = 5 - NumUnits(delegate(Card c) { return true; });
				int numHand = HandSize(delegate(Card c) { return c.name.Contains("PRISM"); });
				int num = min (numOpen, numHand);
				num = min (num, 3);
				numUnitsToCall = num;
				unitsCalled = 0;
				totalUnits = num;
				bEndSkill = false;
				if(numUnitsToCall > 0) 
				{
					bCall = true;
				}
				else
				{
					EndEffect();
					ConfirmAttack();
				}
			}
			else
			{
				CounterBlast(1,
				delegate {
					SelectUnit("Choose one of your rear-guards with \"PRISM\" in its card name.", 1, true,
					delegate {
						ReturnToHand(Unit);
					},
					delegate {
						return Unit.name.Contains("PRISM");
					},
					delegate {
						
					});
				},
				delegate(Card c) {
					return c.name.Contains("PRISM");
				});
			}
		});
		
		if(bCall)
		{
			bCall = false;
			if(numUnitsToCall > 0)
			{
				numUnitsToCall--;
				bEndSkill = true;
				SelectInHand(1, false,
				delegate {
					bEndSkill = false;
					OnlyOpenRC(true);
					CallFromHand(GetHand().GetCurrentCardObject());
				},
				delegate {
					return GetHand().GetCurrentCardObject().name.Contains("PRISM");
				},
				delegate {
					if(bEndSkill)
					{
						EndEffect();
						ConfirmAttack();
					}
				}, "Choose up to " + totalUnits + " units from your hand with \"PRISM\" in its card name.");
			}
		}
		
		CallFromHandUpdate(delegate {
			unitsCalled++;
			OnlyOpenRC(false);
			if(numUnitsToCall > 0)
			{
				bCall = true;
			}
			else
			{
				if(unitsCalled == 3)
				{
					IncreaseCriticalByBattle(OwnerCard, 1);
					IncreasePowerByBattle(OwnerCard, 10000);
				}
				
				EndEffect();
				ConfirmAttack();
			}
		});
	}
	
	public override void Pointer ()
	{
		SelectInHand_Pointer(true);
		SelectUnit_Pointer();
		CounterBlast_Pointer();
	}
}
