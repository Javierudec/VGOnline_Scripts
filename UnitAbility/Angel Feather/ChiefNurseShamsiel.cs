using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Choose an «Angel Feather» from your hand, and put it into your 
 * damage zone] When this unit attacks a vanguard, you may pay the cost. If 
 * you do, choose a card from your damage zone, and put it into your hand.
 * 
 * [AUTO](VC):When a card is put into your damage zone, this unit gets 
 * [Power]+2000 until end of turn.
 */

public class ChiefNurseShamsiel : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () 
			   && LimitBreak(4) 
			   && GetDefensor().IsVanguard()
			   && HandSize(delegate(Card c) { return c.BelongsToClan("Angel Feather"); }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.CardPutInDamage)
		{
			if(VC ())
			{
				IncreasePowerByTurn(OwnerCard, 2000);
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
				FromHandToDamage(_SIH_Card);
			},
			delegate {
				return _SIH_Card.BelongsToClan("Angel Feather");
			},
			delegate {
				SelectInDamage(1, true,
				delegate {
					FromDamageToHand(_SID_Card);
				});
			}, "Choose an \"Angel Feather\" from your hand.");
		});
	}
}
