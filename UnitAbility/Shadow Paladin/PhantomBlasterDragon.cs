using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):If you have a card named "Blaster Dark" 
 * in your soul, this unit gets [Power]+1000.
 * 
 * [ACT](VC):[Counter Blast (2) & Choose three of your 
 * «Shadow Paladin» rear-guards, and retire them] This 
 * unit gets [Power]+10000/[Critical]+1 until end of turn.
 */

public class PhantomBlasterDragon : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.BLASTER_DARK))
		{
			AddContPower (1000);
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && CB (2)
		   && NumUnits(delegate(Card c) { return c.BelongsToClan("Shadow Paladin"); }) >= 3)
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
			CounterBlast(2,
			delegate {
				SelectUnit("Choose three of your \"Shadow Paladi\" rear-guards.", 1, true,
				delegate {
					RetireUnit(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Shadow Paladin");
				},
				delegate {
					IncreasePowerAndCriticalByTurn(OwnerCard, 10000, 1);
				});
			});
		});
	}
}
