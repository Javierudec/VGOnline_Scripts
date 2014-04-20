using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):[Soul Blast (3)] When a «Genesis» rides this unit, you may pay the 
 * cost. If you do, draw two cards, and choose your vanguard, and that unit 
 * gets [Power]+10000 until end of turn.
 * 
 * [AUTO](VC):When this unit attacks a vanguard, Soul Charge (1), and this 
 * unit gets [Power]+1000 until end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class RegaliaOfWisdomAngelica : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{	
			if(VanguardIs("Genesis") && LimitBreak(4) && CanSoulBlast(3) && GetDeck().Size() >= 2)
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC() && GetDefensor().IsVanguard() && GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
				SetBool(1);
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
				SoulBlast(3);
			}
		});
		
		SoulChargeUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 1000);
			EndEffect();
		});
		
		SoulBlastUpdate(delegate {
			DrawCard(2);	
		});
		
		DrawCardUpdate(delegate {
			IncreasePowerByTurn(GetVanguard(), 10000);
			EndEffect();
		});
	}
}
