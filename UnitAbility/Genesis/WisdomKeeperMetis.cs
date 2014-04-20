using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (1)] When a «Genesis» rides this unit, you may pay 
 * the cost. If you do, draw a card, Soul Charge (3), and choose your 
 * vanguard, and that unit gets [Power]+10000 until end of turn.
 * 
 * [AUTO](VC):When this unit attacks a vanguard, Soul Charge (1), and this 
 * unit gets [Power]+1000 until end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class WisdomKeeperMetis : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && GetDeck().Size() > 0 && GetDefensor().IsVanguard())
			{
				SetBool(1);
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Genesis") && CB(1) && LimitBreak(4) && GetDeck().Size() >= 4)
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
			if(GetBool(1))
			{
				SoulCharge(1);
			}
			else
			{
				CounterBlast(1,
				delegate {
					DrawCard(1);
				});
			}
		});
		
		DrawCardUpdate(delegate {
			SoulCharge(3);	
		});
		
		SoulChargeUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				IncreasePowerByBattle(OwnerCard, 1000);
				EndEffect();
				ConfirmAttack();
			}
			else
			{
				IncreasePowerByTurn(GetVanguard(), 10000);
				EndEffect();
			}
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
