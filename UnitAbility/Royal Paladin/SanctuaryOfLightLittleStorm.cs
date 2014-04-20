using UnityEngine;
using System.Collections;

public class SanctuaryOfLightLittleStorm : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.SANCTUARY_OF_LIGHT__PLANET_LANCER))
		{
			AddContPower(1000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().grade == 2 
			   && GetVanguard().BelongsToClan("Royal Paladin")
			   && GetVanguard().cardID != CardIdentifier.SANCTUARY_OF_LIGHT__DETERMINATOR
			   && IsInSoul(CardIdentifier.SANCTUARY_OF_LIGHT__PLANET_LANCER)
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
				return c._CardInfo.cardID == CardIdentifier.SANCTUARY_OF_LIGHT__DETERMINATOR;
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
