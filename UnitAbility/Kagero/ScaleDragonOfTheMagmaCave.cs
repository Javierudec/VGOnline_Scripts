using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Soul Blast (1)] When this unit attacks, if you have a 
 * «Kagerō» vanguard, you may pay the cost. If you do, this unit gets 
 * [Power]+3000 until end of that battle.
 */

public class ScaleDragonOfTheMagmaCave : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(CanSoulBlast(1) && VanguardIs("Kagero"))
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
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 3000);
			EndEffect();
		});
	}
}
