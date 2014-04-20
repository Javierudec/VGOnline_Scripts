using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Choose a «Royal Paladin» from your hand, and 
 * discard it] When this unit attacks, you may pay the cost. If you do, this
 * unit gets [Power]+5000 until end of that battle.
 */

public class HolyDisasterDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(HandSize(delegate(Card c) { return c.BelongsToClan("Royal Paladin"); }) > 0)
			{
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();	
			}
		}	
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, true,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return GetHand().GetCurrentCardObject().BelongsToClan("Royal Paladin");
			},
			delegate {
				IncreasePowerByBattle(OwnerCard, 5000);
				ConfirmAttack();
			}, "Choose a \"Royal Paladin\" from your hand.");
		});
	}
	
	public override void Pointer ()
	{
		SelectInHand_Pointer();
	}
}
