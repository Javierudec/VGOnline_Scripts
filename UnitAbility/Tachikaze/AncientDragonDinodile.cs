using UnityEngine;
using System.Collections;

/*
 * [ACT](RC):[Put this unit into your soul] If you have a 
 * «Tachikaze» vanguard, choose a card from your damage zone, 
 * and turn it face up.
 */

public class AncientDragonDinodile : UnitObject {
	public override int Act ()
	{
		if(RC ()
		   && VanguardIs("Tachikaze"))
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
			MoveToSoul(OwnerCard);
			if(NumUnitsDamage(delegate(Card c) { return !c.IsFaceup(); }) > 0)
			{
				Flipup(1,
				delegate {
					EndEffect();
				});
			}
			else
			{
				EndEffect();
			}
		});
	}
}
