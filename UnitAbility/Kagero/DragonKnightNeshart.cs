using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (2)] When this unit's attack hits, if you have a 
 * «Kagerō» vanguard, you may pay the cost. If you do, draw a card.
 */

public class DragonKnightNeshart : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(CB(2) && VanguardIs("Kagero") && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();	
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
			CounterBlast(2,
			delegate {
				DrawCard(1);
			});
			
			DrawCardUpdate(delegate {
				EndEffect();	
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
