using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC):[Choose a «Kagerō» from your hand, and discard it] When this 
 * unit attacks, you may pay the cost. If you do, this unit gets [Power]+6000 
 * until end of that battle.
 * 
 * [AUTO](RC):[Choose a «Kagerō» from your hand, and discard it] When this 
 * unit attacks, you may pay the cost. If you do, this unit gets [Power]+3000 
 * until end of that battle.
 */

public class DragonKnightMorteza : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(HandSize(delegate(Card c) { return c.BelongsToClan("Kagero"); }) > 0)
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
			SelectInHand(1, true,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return _SIH_Card.BelongsToClan("Kagero");
			},
			delegate {
				if(VC ())
				{
					IncreasePowerByBattle(OwnerCard, 6000);	
				}
				else if(RC ())
				{
					IncreasePowerByBattle(OwnerCard, 3000);	
				}
			}, "Choose a \"Kagero\" from your hand.");
		});
	}
	
	public override void Pointer ()
	{
		SelectInHand_Pointer();
	}
}
