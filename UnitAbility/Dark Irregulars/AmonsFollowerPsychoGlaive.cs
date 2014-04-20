using UnityEngine;
using System.Collections;

public class AmonsFollowerPsychoGlaive : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB(1)
			   && NumUnitsInSoul(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) >= 6
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
				SoulCharge(1);
			});
		});

		SoulChargeUpdate(delegate {
			IncreasePowerByTurn(OwnerCard, 5000);
			EndEffect();
		});
	}
}
