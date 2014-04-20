using UnityEngine;
using System.Collections;

/*
 * [ACT](VC) Limit Break 5 (This ability is active if you have five or more damage):
 * [Counter Blast (3)] Choose up to five of your «Gold Paladin» rear-guards, and those 
 * units get [Power]+5000 until end of turn.
 * 
 * [CONT](VC):If you have a card named "Incandescent Lion, Blond Ezel" in your soul, this
 * unit gets [Power]+2000.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)
 */

public class BlazingLionPlatinaEzel : UnitObject {
	public override void Cont ()
	{
		if(VC()
		   && IsInSoul(CardIdentifier.INCANDESCENT_LION__BLOND_EZEL))
		{
			AddContPower(2000);
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(5)
		   && CB(3)
		   && NumUnits(delegate(Card c) { return c.BelongsToClan("Gold Paladin"); }) > 0)
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

	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(3,
			delegate {
				int num = NumUnits(delegate(Card c) { return c.BelongsToClan("Gold Paladin"); });
				SelectUnit("Choose up to five of your \"Gold Paladin\" rear-guards.", num, true,
				delegate {
					IncreasePowerByTurn(Unit, 5000);
				},
				delegate {
					return Unit.BelongsToClan("Gold Paladin");
				},
				delegate {

				});
			});
		});
	}

	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectUnit_Pointer(true);
	}
}
