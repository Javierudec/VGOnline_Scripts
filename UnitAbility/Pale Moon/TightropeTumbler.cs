using UnityEngine;
using System.Collections;

public class TightropeTumbler : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.CallFromSoul)
		{
			if(VanguardIs("Pale Moon")
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
