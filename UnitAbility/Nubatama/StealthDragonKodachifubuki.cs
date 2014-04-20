using UnityEngine;
using System.Collections;

public class StealthDragonKodachifubuki : UnitObject {
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
		DelayUpdate (delegate {
			CounterBlast(1,
			delegate {
				IncreasePowerByTurn(OwnerCard, 1000);
				EndEffect();
			});
		});
	}
}
