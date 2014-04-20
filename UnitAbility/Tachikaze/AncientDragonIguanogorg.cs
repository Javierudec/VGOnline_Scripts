using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (1)] When this unit is put into the 
 * drop zone from (RC), if you have a vanguard with "Ancient 
 * Dragon" in its card name, you may pay the cost. If you do,
 * call this card to (RC).
 */

public class AncientDragonIguanogorg : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DropZoneFromRC)
		{
			if(CB (1) 
			   && GetVanguard().name.Contains("Ancient Dragon"))
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
			EndEffect ();
		});
	}
}
