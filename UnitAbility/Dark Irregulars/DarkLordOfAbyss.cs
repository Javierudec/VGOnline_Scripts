using UnityEngine;
using System.Collections;

/*
 * [ACT](VC) Limit Break 4 (This ability is active if you have four or 
 * more damage):[Counter Blast (2)] Soul Charge (2), and this unit gets 
 * [Power]+1000 for each «Dark Irregulars» in your soul until end of turn.
 * 
 * [CONT](VC/RC):If you have a non-«Dark Irregulars» vanguard or rear-guard, 
 * this unit gets [Power]-2000.
 */

public class DarkLordOfAbyss : UnitObject {
	public override void Cont ()
	{
		if(NumUnits(delegate(Card c) { return !c.BelongsToClan("Dark Irregulars"); }, true) > 0)
		{
			AddContPower(-2000);
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB(2)
		   && GetDeck().Size() >= 2)
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
				SoulCharge(2);
			});
		});

		SoulChargeUpdate(delegate {
			IncreasePowerByTurn(OwnerCard, 1000 * NumUnitsInSoul(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }));
			EndEffect();
		});
	}
}
