using UnityEngine;
using System.Collections;

public class BarcgalLiberator : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && GetAttacker() == tmp
			   && GetDefensor().IsVanguard()
			   && tmp.cardID == CardIdentifier.BLASTER_BLADE_LIBERATOR
			   && GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			SetBool(1);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, min(3, GetDeck().Size ()), delegate(Game2DCard c) {
				return c._CardInfo.name.Contains("Liberator");
			});
		});

		ResolveDeckOpening(1,
		delegate {
			CallFromDeck (_AuxIdVector);
		},
		delegate {
			EndEffect();
		});

		CallFromDeckUpdate(delegate {
			RestUnit(CallFromDeckList[0]);
			EndEffect();
		});
	}
}
