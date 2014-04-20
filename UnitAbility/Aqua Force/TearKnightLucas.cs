using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (2)] When this unit's attack hits,
 * if you have an «Aqua Force» vanguard, you may pay the cost. If you do,
 * draw a card.
 */

public class TearKnightLucas : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(CB (2)
			   && VanguardIs("Aqua Force")
			   && GetDeck ().Size() > 0)
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
				DrawCard(1);
			});
		});

		DrawCardUpdate(delegate {
			EndEffect();
		});
	}
}
