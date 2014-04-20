using UnityEngine;
using System.Collections;

public class MaidenOfCherryBloom : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard()
			   && CB(1)
			   && CanSoulBlast(1)
			   && VanguardIs("Neo Nectar")
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
				SoulBlast(1);
			});
		});

		SoulBlastUpdate(delegate {
			SetBool(1);
			GetDeck().ViewDeck(1, delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.MAIDEN_OF_CHERRY_STONE;
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
