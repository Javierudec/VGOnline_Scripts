using UnityEngine;
using System.Collections;

public class SilverThornAssistantIrina : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetVanguard().name.Contains("Silver Thorn")
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
