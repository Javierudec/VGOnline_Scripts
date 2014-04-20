using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (1) & Choose three cards with "Eradicator" in its 
 * card name from your hand, and discard them] At the end of the battle that 
 * this unit attacked, if the attack did not hit during that battle, you may pay the 
 * cost. If you do, [Stand] this unit, and this unit gets [Critical]+1 until end of 
 * turn. This ability cannot be used for the rest of that turn.
 * 
 * [ACT](VC):[Counter Blast (2)-card with "Eradicator" in its card name] This 
 * unit gets [Power]+5000 until end of turn.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class EradicatorDragonicDescendant : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackNotHit)
		{
			if(VC() && LimitBreak(4) && CB(1) && HandSize(delegate(Card c) { return c.name.Contains("Eradicator"); }) >= 3 && !GetBool(1))
			{
				SetBool(2);
				DisplayConfirmationWindow();
			}	
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(1);	
		}
	}
	
	public override bool Cancel ()
	{
		UnsetBool(2);
		return true;
	}
	
	public override int Act ()
	{
		if(VC() && CB(2, delegate(Card c) { return c.name.Contains("Eradicator"); }))
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active ()
	{
		if(!GetBool(2))
		{
			StartEffect();
		}
		
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(2))
			{
				UnsetBool(2);
				CounterBlast(1,
				delegate {
					SelectInHand(3, true,
					delegate {
						DiscardSelectedCard();
					},
					delegate {
						return _SIH_Card.name.Contains("Eradicator");
					},
					delegate {
						StandUnit(OwnerCard);
						IncreasePowerAndCriticalByTurn(OwnerCard, 0, 1);
						SetBool(1);
					}, "Choose three cards with \"Eradicator\" in its card name.");
				});
			}
			else
			{
				CounterBlast(2,
				delegate {
					IncreasePowerByTurn(OwnerCard, 5000);
					EndEffect();
				},
				delegate(Card c) {
					return c.name.Contains("Eradicator");
				});
			}
		});
	}
}
