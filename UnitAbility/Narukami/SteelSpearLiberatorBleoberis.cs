using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (1)] When a «Gold Paladin» rides this unit, you may 
 * pay the cost. If you do, look at up to two cards from the top of your deck, 
 * search for up to two «Gold Paladin» from among them, call them to 
 * separate open (RC), and put the rest on the bottom of your deck in any 
 * order, and choose your vanguard, and that unit gets [Power]+10000 until end 
 * of turn.
 * 
 * [AUTO](VC):When this unit attacks a vanguard, this unit gets [Power]+2000 
 * until end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class SteelSpearLiberatorBleoberis : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().BelongsToClan("Gold Paladin") && LimitBreak(4) && CB (1) && GetDeck().Size() > 0 && OpenRC())
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
			CounterBlast(1,
			delegate {
				SetBool(1);
				int num = 5 - NumUnits(delegate(Card c) { return true; });
				GetDeck().ViewDeck(min(2, num), SearchMode.TOP_CARD, 2, delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Gold Paladin");	
				});
			});
		});
		
		if(GetBool(1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{	
				OnlyOpenRC(true);
				CallFromDeck(_AuxIdVector);	
			}
			else
			{
				int n = min (2, GetDeck().Size());
				while(n-- != 0) {
					GetDeck().AddToBottom(GetDeck().DrawCard());	
				}
				EndEffect();
			}
		}
		
		CallFromDeckUpdate(delegate {
			int n = 2 - CallFromDeckList.Count;
			while(n-- != 0) 
			{
				GetDeck().AddToBottom(GetDeck().DrawCard());	
			}
			IncreasePowerByTurn(GetVanguard(), 10000);
			EndEffect();
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
