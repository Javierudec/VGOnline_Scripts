using UnityEngine;
using System.Collections;

/*
 * [CONT](VC/RC):If you do not have another «Kagero» in the same 
 * column as this unit, this card gets [Power]-2000.
 * [ACT](VC/RC):[Counter Blast (1)] This unit gets [Power]+1000 until
 * end of turn.
 */

public class DragonArmoredKnight : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		Card tmp = GetSameColum(OwnerCard.pos);
		if(tmp == null || !tmp.BelongsToClan("Kagero"))
		{
			power -= 2000;	
		}
		SetPower(power);
	}
	
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
