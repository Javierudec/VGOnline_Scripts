using UnityEngine;
using System.Collections;

/*
 * [ACT](RC):[Put this unit into your soul]
 * Choose up to one of your «Great Nature», 
 * and that unit gets [Power]+3000 until end of turn.
 */

public class CastanetDonkey : UnitObject {
	public override int Act ()
	{
		if(RC ())
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
	
	public override void Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			if(NumUnits(delegate(Card c) { return c.BelongsToClan("Great Nature"); }, true) > 0)
			{
				SelectUnit("Choose one of your \"Great Nature\" units.", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 3000);
				},
				delegate {
					return Unit.BelongsToClan("Great Nature");
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
