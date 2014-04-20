using UnityEngine;
using System.Collections;

public class EradicatorTempestBoltDragon : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsPlayerTurn())
		{
			AddContPower(2000 * (NumOpenRC() + NumEnemyOpenRC()));
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB(3, delegate(Card c) { return c.name.Contains("Eradicator"); }))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(3,
			delegate {
				ForEachEnemyUnitOnField(delegate(Card c) {
					RetireEnemyUnit(c);
				});

				ForEachUnitOnField(delegate(Card c) {
					RetireUnit(c);
				});

				EndEffect();
			},
			delegate(Card c) {
				return c.name.Contains("Eradicator");
			});
		});
	}
}
