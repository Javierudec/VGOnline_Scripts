using UnityEngine;
using System.Collections;

public class DancingPrincessOfTheNightSky : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB(1)
			   && VanguardIs("Pale Moon")
			   && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			CounterBlast(1,
			delegate {
				SetBool(1);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Pale Moon") && c._CardInfo.grade <= 2;
				});
			});
		});

		ResolveDeckOpening(1,
		delegate {
			SoulCharge(_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		SoulChargeUpdate(delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
