using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Soul Blast (1)] When this unit's attack hits a 
 * vanguard, if you have a «Spike Brothers» vanguard, you 
 * may pay the cost. If you do, draw a card, and at the 
 * beginning of the close step of that battle, return this unit to 
 * your deck, and shuffle your deck.
 */

public class FierceLeaderZachary : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(RC() && GetDefensor().IsVanguard() && VanguardIs("Spike Brothers") && CanSoulBlast(1))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetBool(1))
			{
				UnsetBool(1);
				FromFieldToDeck(OwnerCard);
				ShuffleDeck(); 
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
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();
			SetBool(1);
			EndEffect();
		});
	}
}
