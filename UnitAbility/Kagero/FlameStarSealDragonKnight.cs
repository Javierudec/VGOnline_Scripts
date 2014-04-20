using UnityEngine;
using System.Collections;

public class FlameStarSealDragonKnight : UnitObject {
	public override int Act ()
	{
		if(CB(1))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				if(GetVanguard().name.Contains("Seal Dragon"))
				{
					ForEachEnemyUnitOnField(delegate(Card c) {
						CantInterceptUntilEndTurn(c);
					});
				}

				EndEffect();
			});
		});
	}
}
