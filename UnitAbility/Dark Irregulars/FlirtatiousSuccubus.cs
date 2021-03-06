﻿using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is placed on (VC) or (RC), if you have a 
 * «Dark Irregulars» vanguard, you may Soul Charge (1).
 */

public class FlirtatiousSuccubus : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(VanguardIs("Dark Irregulars") 
			   && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active ()
	{
		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulCharge(1);
		});

		SoulChargeUpdate(delegate {
			EndEffect();
		});
	}
}
