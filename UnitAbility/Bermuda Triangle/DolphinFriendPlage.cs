using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is put into the drop zone from (GC), put this unit into 
 * your soul.
 */

public class DolphinFriendPlage : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromGC)
		{
			StartEffect();
			ShowAndDelay();
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulChargeFromDrop(OwnerCard);
			EndEffect();
		});
	}
}
