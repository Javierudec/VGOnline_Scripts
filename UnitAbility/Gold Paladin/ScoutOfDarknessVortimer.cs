using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):If you have a card named "Black Dragon Whelp, 
 * Vortimer" in your soul, this unit gets [Power] +1000.
 * 
 * [AUTO]:[Choose one of your «Gold Paladin» rear-guards, and retire it] 
 * When a card named "Black Dragon Knight, Vortimer" rides this unit, if 
 * you have a card named "Black Dragon Whelp, Vortimer" in your soul, 
 * you may pay the cost. If you do, look at up to two cards from the top 
 * of your deck, search for up to two «Gold Paladin» from among them, 
 * call them to separate open (RC), and put the rest on the bottom of your 
 * deck in any order.
 */

public class ScoutOfDarknessVortimer : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(IsInSoul(CardIdentifier.BLACK_DRAGON_WHELP__VORTIMER))
		{
			power += 1000;	
		}
		SetPower(power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.BLACK_DRAGON_KNIGHT__VORTIMER &&
			   IsInSoul(CardIdentifier.BLACK_DRAGON_WHELP__VORTIMER) &&
			   NumUnits(delegate(Card c) { return c.BelongsToClan("Gold Paladin"); }) > 0 &&
			   GetDeck().Size() > 0 &&
			   OpenRC())
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
			SelectUnit("Choose one of your \"Gold Paladin\" rear-guards.", 1, false,
			delegate {
				RetireUnit(Unit);
			},
			delegate {
				return Unit.BelongsToClan("Gold Paladin");
			},
			delegate {
				int numOpenRC = 5 - NumUnits(delegate(Card c) {
					return true;
				});
				
				SetBool(1);
				GetDeck().ViewDeck(min(2, numOpenRC), SearchMode.TOP_CARD, 2, delegate(Game2DCard c) {
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
				int n = 2 - _AuxIdVector.Count;
				while(n-- != 0)
				{
					GetDeck().AddToBottom(GetDeck().DrawCard());	
				}
				
				EndEffect();	
			}
		}
		
		CallFromDeckUpdate(delegate {
			OnlyOpenRC(false);
			EndEffect();	
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
	}
}
