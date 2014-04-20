using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (1)] When a «Shadow Paladin» rides this unit, 
 * you may pay the cost. If you do, choose your vanguard, that unit gets 
 * [Power]+10000 until end of turn, search your deck for up to one grade 
 * 2 or less «Shadow Paladin», call it to (RC), shuffle your deck, and that 
 * unit gets [Power]+5000 until end of turn.
 * 
 * [AUTO](VC):When this unit attacks a vanguard, this unit gets 
 * [Power]+2000 until end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this 
 * unit cannot attack)
 */

public class IllusionaryRevengerMordredPhantom : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(LimitBreak(4) && CB(1) && VanguardIs("Shadow Paladin"))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC () && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
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
			CounterBlast(1,
			delegate {
				IncreasePowerByTurn(GetVanguard(), 10000);
				if(GetDeck().Size() > 0)
				{
					SetBool(1);
					GetDeck().ViewDeck(1, delegate(Game2DCard c) {
						return c._CardInfo.grade <= 2 && c._CardInfo.BelongsToClan("Shadow Paladin");
					});
				}
				else
				{
					EndEffect();	
				}
			});
		});
		
		if(GetBool(1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				EndEffect();
				ShuffleDeck();
			}	
		}
		
		CallFromDeckUpdate(delegate {
			IncreasePowerByTurn(CallFromDeckList[0], 5000);
			EndEffect();
			ShuffleDeck();
		});
	}
	
	public override void Pointer()
	{
		CounterBlast_Pointer();	
	}
}
