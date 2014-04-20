using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):If you have a card named "Angelic Star, Coral" in your soul, 
 * this unit gets [Power]+1000.
 * 
 * [AUTO]:When a grade 2 «Bermuda Triangle» not named "Shiny Star, Coral" 
 * rides this unit, if you have a card named "Angelic Star, Coral" in your soul, 
 * look at up to seven cards from the top of your deck, search for up to one 
 * card named "Shiny Star, Coral" from among them, ride it, and shuffle your deck.
 */

public class FreshStarCoral : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC () && IsInSoul(CardIdentifier.ANGELIC_STAR__CORAL))
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
			if(GetVanguard().grade == 2 && GetVanguard().BelongsToClan("Bermuda Triangle") && GetVanguard().cardID != CardIdentifier.SHINY_STAR__CORAL)
			{
				if(IsInSoul(CardIdentifier.ANGELIC_STAR__CORAL))
				{
					StartEffect();
					ShowAndDelay();
				}
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SetBool(1);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min (7, GetDeck().Size()), delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.SHINY_STAR__CORAL;	
			});
		});
		
		if(GetBool (1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				RideFromDeck(GetDeck().SearchForID(_AuxIdVector[0]));	
			}
			EndEffect();
			ShuffleDeck();
		}
	}
}
