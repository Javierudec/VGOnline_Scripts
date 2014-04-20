using UnityEngine;
using System.Collections;

/*
 * AUTO V/R: When this unit's attack hits a vanguard, if you have 4 
 * or more Megacolony rear-guards, draw a card.
 */

public class TransmutatedThiefStealSpider : UnitObject {
	string clan = "Megacolony";
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() && NumUnits (delegate(Card c) { return c.BelongsToClan(clan); }) >= 4)
			{
				if(GetDeck().Size() > 0)
				{
					StartEffect();
					ShowAndDelay();
				}
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
}
