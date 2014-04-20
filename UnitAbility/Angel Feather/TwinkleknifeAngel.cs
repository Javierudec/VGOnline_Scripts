using UnityEngine;
using System.Collections;

public class TwinkleknifeAngel : UnitObject {
	public override int Act ()
	{
		if(CB (2))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				IncreasePowerByTurn(OwnerCard, 4000);
				EndEffect();
			});
		});
	}
}
