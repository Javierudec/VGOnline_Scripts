using UnityEngine;
using System.Collections;

public class BlackRingChainPleiades : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Link Joker"))
			{
				SetBool(1);
				Forerunner ("Link Joker");
			}
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Active ()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				SetBool(2);
				int n = min(5, GetDeck().Size());
				GetDeck().ViewDeck(1, SearchMode.TOP_CARD, n, delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Link Joker") && c._CardInfo.grade >= 3;
				});
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
