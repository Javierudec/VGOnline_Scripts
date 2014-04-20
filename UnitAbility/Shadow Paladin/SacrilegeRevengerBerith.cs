using UnityEngine;
using System.Collections;

/*
 * [ACT](VC/RC):[Counter Blast (1)] This unit gets [Power]+1000 until
 * end of turn.
 */

public class SacrilegeRevengerBerith : UnitObject {
	public override int Act ()
	{
		if(CB (1)) 
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active()
	{
		StartEffect();	
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				IncreasePowerByTurn(OwnerCard, 1000);
				EndEffect();
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
