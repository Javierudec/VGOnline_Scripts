using UnityEngine;
using System.Collections;

public class MaidenOfCherryStone : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && GetDefensor ().IsVanguard()
			   && GetAttacker() == tmp
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
			FromFieldToDeck(OwnerCard);
			SetBool(1);
			GetDeck().ViewDeck(1, delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.MAIDEN_OF_CHERRY_BLOOM;
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
