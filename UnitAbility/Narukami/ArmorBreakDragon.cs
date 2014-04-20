using UnityEngine;
using System.Collections;

/*
 * [ACT](VC) Limit Break 4 (This ability is active if you have four or 
 * more damage):[Counter Blast (3) & Choose three cards from your hand, 
 * and discard them] Retire all rear-guards in each fighter's front row, 
 * and this unit gets [Power]+10000/[Critical]+2 until end of turn.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class ArmorBreakDragon : UnitObject {
	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB (3)
		   && HandSize() >= 3)
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
			CounterBlast(3,
			delegate {
				SelectInHand(3, true,
				delegate {
					DiscardSelectedCard();
				},
				delegate {
					return true;
				},
				delegate {
					ForEachEnemyUnitOnField(delegate(Card c) {
						if(!c.IsVanguard() && IsFrontRow(c))
						{
							RetireEnemyUnit(c);
						}
					});

					ForEachUnitOnField(delegate(Card c) {
						if(!c.IsVanguard() && IsInFrontRow(c))
						{
							RetireUnit(c);
						}
					});

					IncreasePowerAndCriticalByTurn(OwnerCard, 10000, 2);
				}, "Choose three cards from your hand.");
			});
		});
	}
}
