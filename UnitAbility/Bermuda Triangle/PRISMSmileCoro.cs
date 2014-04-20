using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, you may 
 * call this unit to (RC))
 * 
 * [AUTO](RC):When another of your «Bermuda Triangle» is returned to your 
 * hand from (RC), you may return this unit to your hand.
 */

public class PRISMSmileCoro : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Bermuda Triangle");	
		}
		else if(cs == CardState.HandFromRear_NotMe)
		{
			if(RC () 
			   && ownerEffect.BelongsToClan("Bermuda Triangle"))
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}
	
	public override void Active ()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			ShowAndDelay();
		}
		else
		{
			Forerunner_Active();
		}
	}
	
	public override void Update ()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
}
