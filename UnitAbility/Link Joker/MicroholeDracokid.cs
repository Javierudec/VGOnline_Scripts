using UnityEngine;
using System.Collections;

public class MicroholeDracokid : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.GRAVITY_BALL_DRAGON)
			{
				if(GetDeck().Size() > 0)
				{
					StartEffect();
					ShowAndDelay();
				}
			}
			else
			{
				Forerunner ("Link Joker");
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
			SetBool(2);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min(7, GetDeck().Size()), delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.GRAVITY_COLLAPSE_DRAGON || c._CardInfo.cardID == CardIdentifier.SCHWARZSCHILD_DRAGON;
			});
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
