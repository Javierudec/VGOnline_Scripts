using UnityEngine;
using System.Collections;

/*
 * [ACT](VC/RC): [Counter Blast (2)] This unit gets [Power]+4000 until end of turn.
 */

public class ParabolicMoose : UnitObject {
	public override int Act ()
	{
		if(CB (2)) 
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
			CounterBlast(2,
			delegate {
				IncreasePowerByTurn(OwnerCard, 4000);
				EndEffect();
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
