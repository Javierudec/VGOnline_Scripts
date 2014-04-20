using UnityEngine;
using System.Collections;

public class SanctuaryOfLightDeterminator : UnitObject {
	public override void Cont ()
	{
		if(VC()
		   && IsInSoul(CardIdentifier.SANCTUARY_OF_LIGHT__LITTLE_STORM))
		{
			AddContPower(1000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride)
		{
			if(Game.field.GetLastVanguard().cardID == CardIdentifier.SANCTUARY_OF_LIGHT__LITTLE_STORM
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
			GetDeck().ViewDeck(1, delegate(Game2DCard c) {
				return c._CardInfo.name.Contains("Sanctuary of Light");
			});
		});

		ResolveDeckOpening(1,
		delegate {
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		CallFromDeckUpdate(delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
