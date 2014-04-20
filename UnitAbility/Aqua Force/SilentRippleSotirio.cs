using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):If you have a card named "Starting Ripple, Alecs" 
 * in your soul, this unit gets [Power]+1000.
 * 
 * [AUTO]:When a grade 2 «Aqua Force» not named "Rising Ripple,
 * Pavroth" rides this unit, if you have a card named "Starting 
 * Ripple, Alecs" in your soul, look at up to seven cards from the 
 * top of your deck, search for up to one card named "Rising Ripple,
 * Pavroth" from among them, ride it, and shuffle your deck.
 */

public class SilentRippleSotirio : UnitObject {
	public override void Cont ()
	{
		if(VC()
		   && IsInSoul(CardIdentifier.STARTING_RIPPLE__ALECS))
		{
			AddContPower(1000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().grade == 2
			   && GetVanguard().cardID != CardIdentifier.RISING_RIPPLE__PAVROTH
			   && IsInSoul(CardIdentifier.STARTING_RIPPLE__ALECS)
			   && GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}	

	public override void Update ()
	{
		DelayUpdate(delegate {
			SetBool(1);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min(7, GetDeck().Size()), delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.RISING_RIPPLE__PAVROTH;
			});
		});

		ResolveDeckOpening(1,
		delegate {
			RideFromDeck(GetDeck().SearchForID(_AuxIdVector[0]));
			EndEffect();
			ShuffleDeck();
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
