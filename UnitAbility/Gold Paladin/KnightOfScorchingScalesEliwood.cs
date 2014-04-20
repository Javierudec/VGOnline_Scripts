using UnityEngine;
using System.Collections;

public class KnightOfScorchingScalesEliwood : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride_NotMe)
		{
			if(RC ()
			   && CB(1)
			   && ownerEffect.grade == 3
			   && ownerEffect.name.Contains("Ezel")
			   && GetDeck().Size() > 0
			   && OpenRC())
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
				GetDeck().ViewDeck(1, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, 1, delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Gold Paladin");
				});
			});
		});

		ResolveDeckOpening(1,
		delegate {
			OnlyOpenRC(true);
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
		});

		CallFromDeckUpdate(delegate {
			OnlyOpenRC(false);
			EndEffect();
		});
	}
}
