using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (1) & Choose a «Kagerō» from your hand, and 
 * discard it] When this unit attacks a vanguard, you may pay the cost. If you 
 * do, this unit gets [Power]+5000/[Critical]+1 until end of that battle.
 * 
 * [CONT](VC):During your turn, if this unit's [Critical] is two or greater, this unit 
 * gets [Power]+5000.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class BlastBulkDragon : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC () && IsPlayerTurn() && OwnerCard.GetCritical() >= 2)
		{
			power += 5000;	
		}
		SetPower(power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC() && LimitBreak(4) && CB(1) && HandSize(delegate(Card c) { return c.BelongsToClan("Kagero"); }) > 0 && GetDefensor().IsVanguard())
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectInHand(1, true,
				delegate {
					DiscardSelectedCard();
				},
				delegate {
					return _SIH_Card.BelongsToClan("Kagero");
				},
				delegate {
					IncreasePowerByBattle(OwnerCard, 5000);
					IncreaseCriticalByBattle(OwnerCard, 1);
				}, "Choose a \"Kagero\" from your hand.");
			});
		});
	}
}
