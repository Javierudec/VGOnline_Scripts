using UnityEngine;
using System.Collections;

public class RevengerDarkBondTrumpeter : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB (1)
			   && VanguardIs("Shadow Paladin")
			   && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SetBool(1);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.name.Contains("Revenger") && c._CardInfo.grade == 0;
				});
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
			RestUnit(CallFromDeckList[0]);
			EndEffect();
			ShuffleDeck();
		});
	}
}
