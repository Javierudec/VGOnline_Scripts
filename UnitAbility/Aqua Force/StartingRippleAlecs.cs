using UnityEngine;
using System.Collections;

/*
 * [AUTO]: When a card named "Silent Ripple, Sotirio" rides this unit, 
 * look at up to seven cards from the top of your deck, search for up 
 * to one card named "Rising Ripple, Pavroth" or "Thundering Ripple, 
 * Genovious" from among them, reveal it to your opponent, put it into
 * your hand, and shuffle your deck.
 *
 * [AUTO]: When an «Aqua Force» other than a card named "Silent Ripple, 
 * Sotirio" rides this unit, you may call this card to (RC).
 */

public class StartingRippleAlecs : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.SILENT_RIPPLE__SOTIRIO)
			{
				if(GetDeck ().Size() > 0)
				{
					StartEffect();
					ShowAndDelay();
				}
			}
			else
			{
				Forerunner("Aqua Force");
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
			GetDeck ().ViewDeck(1, SearchMode.TOP_CARD, min(7, GetDeck().Size()), delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.RISING_RIPPLE__PAVROTH || c._CardInfo.cardID == CardIdentifier.THUNDERING_RIPPLE__GENOVIOUS;
			});
		});

		ResolveDeckOpening(1,
		delegate {
			FromDeckToHand(_AuxIdVector[0]);
			EndEffect();
			ShuffleDeck();
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
