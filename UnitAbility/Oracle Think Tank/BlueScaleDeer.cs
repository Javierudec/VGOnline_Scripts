using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Soul Blast (2)] When this unit's attack hits a 
 * vanguard, if you have an «Oracle Think Tank» vanguard, you may pay 
 * the cost. If you do, draw a card.
 */

public class BlueScaleDeer : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() && CanSoulBlast(2) && VanguardIs("Oracle Think Tank") && GetDeck().Size() > 0)
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
			SoulBlast(2);	
		});
		
		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
}
