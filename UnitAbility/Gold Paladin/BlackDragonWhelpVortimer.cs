using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When a card named "Scout of Darkness, 
 * Vortimer" rides this unit, look at up to seven cards from 
 * the top of your deck, search for up to one card named 
 * "Spectral Duke Dragon" or "Black Dragon Knight, 
 * Vortimer" from among them, reveal it to your opponent, 
 * put it into your hand, and shuffle your deck. [AUTO]:When 
 * a «Gold Paladin» other than a card named "Scout of 
 * Darkness, Vortimer" rides this unit, you may call this card to (RC).
 */

public class BlackDragonWhelpVortimer : UnitObject {
	CardIdentifier rideUnit = CardIdentifier.SCOUT_OF_DARKNESS__VORTIMER;
	CardIdentifier searchFor = CardIdentifier.SPECTRAL_DUKE_DRAGON;
	CardIdentifier searchFor2 = CardIdentifier.BLACK_DRAGON_KNIGHT__VORTIMER;
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack ();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == rideUnit)
			{
				StartEffect();
				ShowAndDelay();
			}
			else
			{
				Forerunner("Gold Paladin");	
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
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min (7, GetDeck().Size()), delegate(Game2DCard c) {
				return c._CardInfo.cardID == searchFor || c._CardInfo.cardID == searchFor2;	
			});
		});
		
		if(GetBool (1) && !GetDeck().IsOpen())
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
