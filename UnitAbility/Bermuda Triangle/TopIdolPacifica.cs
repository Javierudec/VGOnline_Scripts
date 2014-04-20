using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):During your turn, if the number of «Bermuda Triangle» rear-
 * guards you have is four or more, this unit gets [Power]+3000.
 * 
 * [AUTO](VC):At the beginning of your main phase, Soul Charge (1), draw a 
 * card, choose a card from your hand, and put it on the bottom of your deck.
 * 
 * [AUTO](VC/RC):[Soul Blast (8) & Counter Blast (5)] When this unit's attack 
 * hits a vanguard, you may pay the cost. If you do, search your deck up to 
 * three «Bermuda Triangle», call them to separate (RC), and shuffle your deck.
 */

public class TopIdolPacifica : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC () && IsPlayerTurn() && NumUnits(delegate(Card c) { return c.BelongsToClan("Bermuda Triangle"); }) >= 4)
		{
			power += 3000;	
		}
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.BeginMain)
		{
			if(VC () && GetDeck().Size() >= 2)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() && CanSoulBlast(8) && CB(5))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active ()
	{
		SetBool(1);
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				SoulBlast(8);	
			}
			else
			{
				SoulCharge(1);
			}
		});
		
		SoulBlastUpdate(delegate {
			CounterBlast(5,
			delegate {
				SetBool(2);
				GetDeck().ViewDeck(min(3, GetDeck().Size()), delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Bermuda Triangle");	
				});
			});
		});
		
		if(GetBool(2) && !GetDeck().IsOpen())
		{
			UnsetBool(2);
			_AuxIdVector = GetDeck().GetLastSelectedList();
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
			EndEffect();
			ShuffleDeck();
		});
		
		SoulChargeUpdate(delegate {
			DrawCard(1);
		});
		
		DrawCardUpdate(delegate {
			SelectInHand(1, true,
			delegate {
				ReturnCardFromHandToDeck(true, false);
			},
			delegate {
				return true;
			},
			delegate {
				
			}, "Choose a card from your hand.");
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
