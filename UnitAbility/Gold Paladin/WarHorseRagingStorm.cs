using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is placed on (VC) or (RC), if you have a «Gold 
 * Paladin» vanguard, choose up to one «Gold Paladin» from your hand, 
 * and put it into your soul.
 */

public class WarHorseRagingStorm : UnitObject {
	public string clan = "Gold Paladin";
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(VanguardIs(clan) && HandSize(delegate(Card c) { return c.BelongsToClan(clan); }) > 0)
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
			SelectInHand(1, false, 
			delegate {
				FromHandToSoul(GetHand().GetCurrentCardObject(), GetHand().GetCurrentCard());
			},
			delegate {
				return GetHand().GetCurrentCardObject().BelongsToClan(clan);
			},
			delegate {
				
			}, "Choose a \"" + clan + "\" from your hand.");
		});
		
		FromHandToSoulUpdate(delegate {
			EndEffect ();	
		});
	}
	
	public override void Pointer ()
	{
		SelectInHand_Pointer();
	}
}
