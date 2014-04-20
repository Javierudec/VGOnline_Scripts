using UnityEngine;
using System.Collections;

/*
 * [ACT](VC/RC):[Counter Blast (1)] If you have four or more other 
 * «Gold Paladin» rear-guards, this unit gets [Power]+2000 until end of turn.
 */

public class SleygalDagger : UnitObject {
	public override int Act ()
	{
		if(CB(1))
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
			CounterBlast(1,
				delegate {
				if(NumUnits(delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Gold Paladin"); }) >= 4)
				{
					IncreasePowerByTurn(OwnerCard, 2000);
				}
				EndEffect();
			});
		});
	}
}
