using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Counter Blast (1)] When this unit's attack hits a vanguard, if 
 * you have a «Bermuda Triangle» vanguard, you may pay the cost. If you do, 
 * return this unit to your hand, choose up to one «Bermuda Triangle» from 
 * your hand other than a card named "Pretty Celeb, Charlotte", and call it to an 
 * open (RC).
 */

public class PrettyCelebCharlotte : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(RC() && CB(1) && GetDefensor().IsVanguard() && VanguardIs("Bermuda Triangle"))
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
			CounterBlast(1,
			delegate {
				ReturnToHand(OwnerCard);
				if(HandSize(delegate(Card c) { return c.cardID != CardIdentifier.PRETTY_CELEB__CHARLOTTE && c.BelongsToClan("Bermuda Triangle"); }) > 0)
				{
					SelectInHand(1, false,
					delegate {
						OnlyOpenRC(true);
						CallFromHand(_SIH_Card);
					},
					delegate {
						return _SIH_Card.BelongsToClan("Bermuda Triangle") && _SIH_Card.cardID != CardIdentifier.PRETTY_CELEB__CHARLOTTE;
					},
					delegate {
						
					}, "Choose a \"Bermuda Triangle\" other than \"Pretty Celeb, Charlotte\" from your hand.");
				}
				else
				{
					EndEffect();	
				}
			});
		});
		
		CallFromHandUpdate(delegate {
			OnlyOpenRC(false);
			EndEffect();	
		});
	}
	
	public override void Pointer ()
	{
		SelectInHand_Pointer();
		CounterBlast_Pointer();
	}
}
