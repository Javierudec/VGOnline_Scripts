using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is placed on (VC) or (RC), if you 
 * have a «Spike Brothers» vanguard, you may Soul Charge 
 * (1).
 */

public class MedicalManager : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetDeck().Size() > 0)
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
