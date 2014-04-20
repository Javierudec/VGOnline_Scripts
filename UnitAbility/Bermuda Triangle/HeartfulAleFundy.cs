using UnityEngine;
using System.Collections;

/*
 * [ACT](RC):[Put this unit into your soul] Choose up to one of your «Bermuda 
 * Triangle», and that unit gets [Power]+3000 until end of turn.
 */

public class HeartfulAleFundy : UnitObject {
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
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			if(NumUnits(delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Bermuda Triangle"); }, true) > 0)
			{
				SelectUnit("Choose up to one of your \"Bermuda Triangle\".", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 3000);
				},
				delegate {
					return Unit != OwnerCard && Unit.BelongsToClan("Bermuda Triangle");
				},
				delegate {
					
				}, true);
			}
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
	}
}
