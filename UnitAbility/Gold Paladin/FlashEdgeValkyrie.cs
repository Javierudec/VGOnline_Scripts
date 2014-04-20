using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (1)] When this unit is placed on (RC) from your 
 * deck, if you have a «Gold Paladin» vanguard, you may pay the cost. If 
 * you do, look at the top card of your deck, search for up to one «Gold 
 * Paladin» from among them, call it to an open (RC), and put the rest on 
 * the bottom of your deck.
 */

public class FlashEdgeValkyrie : UnitObject {
	public override void Auto(CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.CallFromDeck)
		{
			if(CB (1) && VanguardIs("Gold Paladin") && GetDeck().Size() > 0 && OpenRC())
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();	
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SetBool(1);
				GetDeck().ViewDeck(1, SearchMode.TOP_CARD, 1, delegate(Game2DCard c) {
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
				GetDeck().AddToBottom(GetDeck().DrawCard());
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
		CounterBlast_Pointer();
	}
}

