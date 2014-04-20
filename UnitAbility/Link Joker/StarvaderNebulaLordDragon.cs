using UnityEngine;
using System.Collections;

public class StarvaderNebulaLordDragon : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && IsPlayerTurn())
		{
			int n = NumEnemyUnits(delegate(Card d) { return d.IsLocked(); }, true, true);
			ForEachUnitOnField(delegate(Card c) {
				if(c.BelongsToClan("Link Joker") && IsInFrontRow(c))
				{
					c.unitAbilities.SetPower(3000 * n);
				}
			});
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && CB (2)
		   && NumEnemyUnits(delegate(Card c) { return !IsFrontRow(c, true); }) > 0)
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
			CounterBlast(2,
			delegate {
				SelectEnemyUnit("Choose one of your opponent's rear-guards in the back row.", 1, true,
				delegate {
					LockEnemyUnit(EnemyUnit);
				},
				delegate {
					return !IsFrontRow(EnemyUnit);
				},
				delegate {

				});
			});
		});
	}
}
