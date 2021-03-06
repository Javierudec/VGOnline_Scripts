﻿using UnityEngine;
using System.Collections;

public class OrangeWitchValencia : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DropFromSoul)
		{
			if(VanguardIs("Genesis")
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
