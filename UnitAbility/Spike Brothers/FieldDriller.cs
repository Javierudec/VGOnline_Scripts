using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):When this unit's attack hits a vanguard, if 
 * the number of other «Spike Brothers» rear-guards you 
 * have is four or more, draw a card.
 */

public class FieldDriller : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard())
			{
				if(NumUnits(delegate(Card c) { return c.BelongsToClan("Spike Brothers") && c != OwnerCard; }) >= 4)
				{
					DrawCardWithoutDelay();	
				}
			}
		}
	}
}
