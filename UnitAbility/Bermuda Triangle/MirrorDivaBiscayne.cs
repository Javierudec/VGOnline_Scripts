using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Soul Blast (1)] When this unit is placed on (RC), if you have a 
 * «Bermuda Triangle» vanguard, you may pay the cost. If you do, look 
 * at up to seven cards from the top of your deck, search for up to one 
 * card named "Mirror Diva, Biscayne" from among them, reveal it to 
 * your opponent, put it into your hand, and shuffle your deck.
 */

public class MirrorDivaBiscayne : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(CanSoulBlast(1) && VanguardIs("Bermuda Triangle"))
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
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			SetBool(1);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min (7, GetDeck().Size()), delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.MIRROR_DIVA__BISCAYNE;	
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
			EndEffect();
			ShuffleDeck();
		}
	}
}
