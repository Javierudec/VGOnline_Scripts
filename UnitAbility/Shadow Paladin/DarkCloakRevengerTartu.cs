using UnityEngine;
using System.Collections;

public class DarkCloakRevengerTartu : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB(2)
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
			CounterBlast(2,
			delegate {
				SetBool(1);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.name.Contains("Revenger") && c._CardInfo.grade <= 1;
				});
			});
		});

		ResolveDeckOpening(1,
		delegate {
			/*
			Game.CallFromDeck_AddConstraint(delegate(Card c) {
				return c.pos == GetSameColumPosition(OwnerCard.pos);
			});
			*/
			Game.bCallToSameColum = true;
			Game.bCallSameColPos = OwnerCard.pos;

			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		CallFromDeckUpdate(delegate {
			//Game.CallFromDeck_RemoveConstraint();
			EndEffect();
			ShuffleDeck();
		});
	}
}
