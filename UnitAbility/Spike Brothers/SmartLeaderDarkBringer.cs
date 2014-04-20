using UnityEngine;
using System.Collections;

/*
 * [AUTO]: When another «Spike Brothers» rides on this unit, you may 
 * call this card to (RC). 
 * [AUTO](RC): [Put this unit into your soul] When this unit's attack hits, you may pay the cost. If you do, 
 * choose up to one «Spike Brothers» from your hand, and call it to (RC).
 */

public class SmartLeaderDarkBringer : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.RideAboveIt)
		{
			Forerunner("Spike Brothers");	
		}
		else if(cs == CardState.AttackHits)
		{
			SetBool(1);
			DisplayConfirmationWindow();	
		}
	}
	
	public override void Active ()
	{
		if(GetBool(1))
		{
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
			MoveToSoul(OwnerCard);
			if(HandSize(delegate(Card c) { return c.BelongsToClan("Spike Brothers"); }) > 0)
			{
				SelectInHand(1, false,
				delegate {
					CallFromHand(GetHand().GetCurrentCardObject());
				},
				delegate {
					return GetHand().GetCurrentCardObject().BelongsToClan("Spike Brothers");
				},
				delegate {
					
				}, "Choose a \"Spike Brothers\" from your hand.");
			}
		});
		
		CallFromHandUpdate(delegate {
			EndEffect();	
		});
	}
	
	public override void Pointer ()
	{
		SelectInHand_Pointer();
	}
}
