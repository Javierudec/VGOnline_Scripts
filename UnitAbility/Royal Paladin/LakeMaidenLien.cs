using UnityEngine;
using System.Collections;

/*
 * [ACT](VC/RC):[Rest this unit & Choose a card from your hand, and discard 
 * it] Draw a card.
 */

public class LakeMaidenLien : UnitObject {
	public override int Act ()
	{
		if(OwnerCard.IsStand() && HandSize() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			RestUnit(OwnerCard);
			SelectInHand(1, true,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return true;
			},
			delegate {
				DrawCard(1);
			}, "Choose a card from your hand.");
		});
		
		DrawCardUpdate(delegate {
			EndEffect();	
		});
	}
}
