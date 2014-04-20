using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is placed on (VC), choose up to one card 
 * named "Blaster Blade" from your soul, and call it to (RC).
 */

public class AlfredEarly : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride)
		{
			if(IsInSoul(CardIdentifier.BLASTER_BLADE))
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
			CallFromSoul(Game.field.SearchInSoulForID(CardIdentifier.BLASTER_BLADE));	
		});
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
}
