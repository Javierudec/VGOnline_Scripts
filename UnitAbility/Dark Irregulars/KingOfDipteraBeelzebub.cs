using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):If the number of «Dark Irregulars» in your soul is eight or
 * more, this unit gets [Power]+1000.
 * 
 * [AUTO](VC):[Counter Blast (2)] When this unit attacks, if the number of 
 * «Dark Irregulars» in your soul is six or more, you may pay the cost. 
 * If you do, choose up to two of your «Dark Irregulars» rear-guards, and 
 * those units get [Power]+3000 until end of turn.
 */

public class KingOfDipteraBeelzebub : UnitObject {
	public override void Cont ()
	{
		if(VC()
		   && NumUnitsInSoul(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) >= 8)
		{
			AddContPower(1000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && CB(2)
			   && NumUnitsInSoul(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) >= 6
			   && NumUnits (delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active ()
	{
		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
				delegate {
				int num = min (2, NumUnits(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }));
				SelectUnit("Choose up to " + num + " of your \"Dark Irregulars\" rear-guards.", num, true,
				delegate {
					IncreasePowerByTurn(Unit, 3000);
				},
				delegate {
					return Unit.BelongsToClan("Dark Irregulars");
				},
				delegate {

				});
			});
		});
	}

	public override void Pointer()
	{
		SelectUnit_Pointer(true);
		CounterBlast_Pointer();
	}
}
