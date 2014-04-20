using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):When a «Genesis» rides this unit, choose up to two of your 
 * «Genesis» rear-guards, those units get [Power]+5000 until end of turn, and 
 * choose your vanguard, and until end of turn, that unit gets [Power]+10000 
 * and "[AUTO](VC):[Soul Blast (3)] When this unit attacks a vanguard, you 
 * may pay the cost. If you do, draw a card.".
 * 
 * [AUTO](VC):When this unit attacks a vanguard, Soul Charge (1), and this 
 * unit gets [Power]+1000 until end of turn.
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class OracleQueenHimiko : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(LimitBreak(4) && VanguardIs("Genesis"))
			{
				IncreasePowerByTurn(GetVanguard(), 10000);
				GetVanguard().unitAbilities.AddUnitObject(new OracleQueenHimikoExternEffect());
				if(NumUnits(delegate(Card c) { return c.BelongsToClan("Genesis"); }) > 0)
				{
					StartEffect();
					ShowAndDelay();
				}
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC() && GetDeck().Size() > 0 && GetDefensor().IsVanguard())
			{
				StartEffect();
				ShowAndDelay();
				SetBool(1);
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate (delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SoulCharge(1);	
			}
			else
			{
				int num = min (2, NumUnits(delegate(Card c) { return c.BelongsToClan("Genesis"); }));
				SelectUnit("Choose up to " + num + " of your \"Genesis\" rear-guards.", num, true,
				delegate {
					IncreasePowerByTurn(Unit, 5000);
				},
				delegate {
					return Unit.BelongsToClan("Genesis");
				},
				delegate {
				
				});
			}
		});
		
		SoulChargeUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 1000);
			EndEffect();
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer(true);
	}
}

public class OracleQueenHimikoExternEffect : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC() && CanSoulBlast(3) && GetDefensor().IsVanguard())
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
			SoulBlast(3);	
		});
		
		SoulBlastUpdate(delegate {
			DrawCard(1);	
		});
		
		DrawCardUpdate(delegate {
			EndEffect();	
		});
	}
}
