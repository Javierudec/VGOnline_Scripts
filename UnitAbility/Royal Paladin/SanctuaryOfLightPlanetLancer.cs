using UnityEngine;
using System.Collections;

public class SanctuaryOfLightPlanetLancer : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.SANCTUARY_OF_LIGHT__LITTLE_STORM)
			{
				if(GetDeck().Size() > 0)
				{
					StartEffect();
					ShowAndDelay();
					SetBool(1);
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

		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SetBool(2);
				GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min(7, GetDeck().Size()), delegate(Game2DCard c) {
					return c._CardInfo.cardID == CardIdentifier.SANCTUARY_OF_LIGHT__DETERMINATOR || c._CardInfo.cardID == CardIdentifier.SANCTUARY_OF_LIGHT__PLANETAL_DRAGON;
				});
			}
		});

		ResolveDeckOpening(2,
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
