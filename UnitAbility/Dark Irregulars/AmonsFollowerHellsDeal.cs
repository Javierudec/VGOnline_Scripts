using UnityEngine;
using System.Collections;

public class AmonsFollowerHellsDeal : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(VanguardIs("Dark Irregulars")
			   && GetDeck().Size() >= 2)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulCharge(2);
		});

		SoulChargeUpdate(delegate {
			EndEffect();
		});
	}
}
