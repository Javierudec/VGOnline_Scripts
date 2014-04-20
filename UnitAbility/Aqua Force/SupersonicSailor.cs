using UnityEngine;
using System.Collections;

/*
 * [ACT](RC):[Put this unit into your soul] 
 * If you have a «Aqua Force» vanguard, choose up to one card from your damage zone, and turn it face up.
 */

public class SupersonicSailor : UnitObject {
	public override int Act ()
	{
		if(RC ())
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
			if(VanguardIs("Aqua Force"))
			{
				Flipup(min (1, GetFaceupDamage()),
				delegate {
					EndEffect();
				});
			}
		});
	}
	
	public override void Pointer ()
	{
		Flipup_Pointer();
	}
}
