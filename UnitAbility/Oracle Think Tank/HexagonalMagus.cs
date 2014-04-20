using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):When a «Oracle Think Tank» rides this unit, look at three cards 
 * from the top of your deck, search for one card from among them, put it into 
 * your hand, put the rest on the top of your deck in any order, and choose 
 * your vanguard, and that unit gets [Power]+10000 until end of turn.
 * 
 * [CONT](VC):During your turn, if the number of cards in your hand is four or 
 * greater, this unit gets [Power]+2000.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class HexagonalMagus : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC() && IsPlayerTurn() && HandSize() >= 4)
		{
			power += 2000;	
		}
		SetPower (power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Oracle Think Tank") && GetDeck().Size() >= 3)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate (delegate {
			SetBool(1);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD_WITH_REORDER, 3, delegate(Game2DCard c) {
				return true;	
			});
		});
		
		if(GetBool(1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				FromDeckToHand(_AuxIdVector[0]);	
			}
			IncreasePowerByTurn(GetVanguard(), 10000);
			EndEffect();
		}
	}
}
