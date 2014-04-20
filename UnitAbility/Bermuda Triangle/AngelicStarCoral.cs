using UnityEngine;
using System.Collections;

/*
 * [AUTO]: When a card named "Fresh Star, Coral" rides this unit, look at 
 * up to seven cards from the top of your deck, search for up to one card
 * named "Aurora Star, Coral" or "Shiny Star, Coral" from among them, 
 * reveal it to your opponent, put it into your hand, and shuffle your deck.
 * 
 * [AUTO]: When a «Bermuda Triangle» not named "Fresh Star, Coral" 
 * rides this unit, you may call this unit to (RC).
 */

public class AngelicStarCoral : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.FRESH_STAR__CORAL && GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
			else
			{
				Forerunner("Bermuda Triangle");	
			}
		}
	}
	
	public override void Active ()
	{
		Forerunner_Active();
	}
	
	public override void Update ()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			SetBool(1);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min(7, GetDeck().Size()), delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.AURORA_STAR__CORAL || c._CardInfo.cardID == CardIdentifier.SHINY_STAR__CORAL;	
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
