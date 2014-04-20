using UnityEngine;
using System.Collections;

/*
 * [ACT](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (2)-card with "Seal Dragon" in its card name] 
 * Retire all of your opponent's grade 2 rear-guards, and this unit gets 
 * [Power]+10000 until end of turn.
 * 
 * [CONT](VC):If you have a card named "Seal Dragon, Blockade" in your soul,
 * this unit gets [Power]+2000.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class HellfireSealDragonBlockadeInferno : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.SEAL_DRAGON_BLOCKADE))
		{
			AddContPower(2000);
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB (2, delegate(Card c) { return c.name.Contains("Seal Dragon"); }))
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
			CounterBlast(2,
			delegate {
				ForEachEnemyUnitOnField(delegate(Card c) {
					if(!c.IsVanguard()
					   && c.grade == 2)
					{
						RetireEnemyUnit(c);
					}
				});
				IncreasePowerByTurn(OwnerCard, 10000);
				EndEffect();
			},
			delegate(Card c) {
				return c.name.Contains("Seal Dragon");
			});
		});
	}
}
