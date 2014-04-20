using UnityEngine;
using System.Collections;

/*
 * [AUTO] (VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (2) & Choose a card named "Grateful Catapult" 
 * from your hand, and discard it] When this unit attacks a vanguard, you may 
 * pay the cost. If you do, search your deck for up to two «Spike Brothers», 
 * call them to open (RC), and shuffle your deck.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class GratefulCatapult : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC() && LimitBreak(4) && CB(2) && IsInHand(CardIdentifier.GRATEFUL_CATAPULT) && OpenRC())
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
			CounterBlast(2,
				delegate {
				SelectInHand(1, false,
				delegate {
					DiscardSelectedCard();
				},
				delegate {
					return _SIH_Card.cardID == CardIdentifier.GRATEFUL_CATAPULT;
				},
				delegate {
					SetBool(1);
					GetDeck().ViewDeck(min(2, NumOpenRC()), delegate(Game2DCard c) {
						return c._CardInfo.BelongsToClan("Spike Brothers");	
					});				
				}, "Choose a card named \"Grateful Catapult\" from your hand.");
			});
		});
		
		ResolveDeckOpening(1,
		delegate {
			OnlyOpenRC(true);
			CallFromDeck(_AuxIdVector);	
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});
		
		CallFromDeckUpdate(delegate {
			OnlyOpenRC(false);
			EndEffect();
		});
	}
}
