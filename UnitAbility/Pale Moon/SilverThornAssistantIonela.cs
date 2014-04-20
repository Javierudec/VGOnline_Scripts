using UnityEngine;
using System.Collections;

public class SilverThornAssistantIonela : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Pale Moon");
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && GetDefensor().IsVanguard()
			   && GetAttacker() == tmp
			   && tmp.name.Contains("Silver Thorn")
			   && GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Active ()
	{
		Forerunner_Active();
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			SetBool(1);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, min(2, GetDeck().Size()), delegate(Game2DCard c) {
				return c._CardInfo.name.Contains("Silver Thorn");
			});
		});

		ResolveDeckOpening(1,
		delegate {
			SoulCharge(_AuxIdVector);
		},
		delegate {
			EndEffect();
		});

		SoulChargeUpdate(delegate {
			EndEffect();
		});
	}
}
