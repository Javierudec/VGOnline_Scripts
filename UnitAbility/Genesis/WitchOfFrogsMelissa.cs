using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (1)] When this unit is put into the 
 * drop zone from your soul, if you have a «Genesis» vanguard, 
 * you may pay the cost. If you do, call this unit to (RC).
 */

public class WitchOfFrogsMelissa : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DropFromSoul)
		{
			if(CB (1)
			   && VanguardIs("Genesis"))
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
				CallFromDrop(OwnerCard);
			});
		});
		
		CallFromDropUpdate(delegate {
			EndEffect();
		});
	}
}
