using UnityEngine;
using System.Collections;

/*
 * AUTO: When a card named "Eye of Destruction, Zeal" rides this unit,
 * look at up to seven cards from the top of your deck, search for up 
 * to one card named "Galactic Beast, Zeal" or "Devourer of Planets, 
 * Zeal" from among them, reveal it to your opponent, put it into your 
 * hand, and shuffle your deck.
 * 
 * AUTO: When a «Dimension Police» other than a card named "Eye of Destruction,
 * Zeal" rides this unit, you may call this card to Rear-guard Circle.
 */

public class LarvaBeastZeal : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.EYE_OF_DESTRUCTION__ZEAL)
			{
				if(GetDeck().Size() > 0)
				{
					StartEffect();
					ShowAndDelay();
				}
			}
			else
			{
				Forerunner(OwnerCard.clan);
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

		DelayUpdate (delegate {
			int n = min (7, GetDeck().Size());
			SetBool(1);
			GetDeck ().ViewDeck(1, SearchMode.TOP_CARD, n,
			delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.GALACTIC_BEAST__ZEAL
					|| c._CardInfo.cardID == CardIdentifier.DEVOURER_OF_PLANETS__ZEAL;
			});
		});

		ResolveDeckOpening (1,
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
