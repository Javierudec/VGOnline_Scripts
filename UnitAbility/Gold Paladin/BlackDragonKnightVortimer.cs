using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):If you have a card named "Scout of 
 * Darkness, Vortimer" in your soul, this unit gets 
 * [Power]+1000.
 * [AUTO]:[Choose one of your «Gold Paladin» rear-guards, 
 * and retire it] When a card named "Spectral Duke Dragon" 
 * rides this unit, if you have a card named "Scout of 
 * Darkness, Vortimer" in your soul, you may pay the cost. If 
 * you do, look at up to two cards from the top of your deck, 
 * search for up to two «Gold Paladin» from among them, call them 
 * to separate open (RC), and put the rest on the 
 * bottom of your deck in any order.
 */

public class BlackDragonKnightVortimer : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC() && IsInSoul(CardIdentifier.SCOUT_OF_DARKNESS__VORTIMER))
		{
			power += 1000;	
		}
		SetPower(power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack ();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.SPECTRAL_DUKE_DRAGON && IsInSoul(CardIdentifier.SCOUT_OF_DARKNESS__VORTIMER))
			{
				if(NumUnits(delegate(Card c) { return c.BelongsToClan("Gold Paladin"); }) > 0)
				{
					DisplayConfirmationWindow();	
				}
			}
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();	
	}
	
	public override void Update()
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
				SetBool(1);
				GetDeck().ViewDeck(2, SearchMode.TOP_CARD, min (2, GetDeck().Size()), delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Gold Paladin");
				});
			});
		});
		
		if(GetBool(1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			_AuxInt1 = _AuxIdVector.Count;
			if(_AuxIdVector.Count > 0)
			{
				CallFromDeck(_AuxIdVector);	
			}
			else
			{
				EndEffect();	
			}
		}
		
		CallFromDeckUpdate(delegate {
			int returnToBottom = 2 - _AuxInt1;
			while(returnToBottom-- != 0)
			{
				GetDeck().AddToBottom(GetDeck().DrawCard());	
			}
			EndEffect();
		});
	}
	
	public override void Pointer()
	{
		SelectUnit_Pointer();	
	}
}
