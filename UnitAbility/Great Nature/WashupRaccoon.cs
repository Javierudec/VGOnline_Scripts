using UnityEngine;
using System.Collections;

public class WashupRaccoon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DropZoneFromRC)
		{
			if(CB(1)
			   && NumUnitsDrop(delegate(Card c) { return c.grade >= 1 && c.BelongsToClan("Great Nature") && c.cardID != CardIdentifier.WASHUP_RACCOON; }) >= 3
			   && CurrentPhaseIs(GamePhase.ENDTURN)
			   && VanguardIs("Great Nature")
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
				Game.field.ViewDropZone(1, delegate(Card c) {
					return c.grade >= 1 && c.BelongsToClan("Great Nature") && c.cardID != CardIdentifier.WASHUP_RACCOON;
				});
			});
		});

		ResolveDropOpening(1,
		delegate {
			FromDropToDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
		});

		FromDropToDeckUpdate(delegate {
			SetBool(2);
			GetDeck().ViewDeck(1, delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.WASHUP_RACCOON;
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
