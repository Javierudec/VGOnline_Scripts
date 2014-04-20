using UnityEngine;
using System.Collections;

public class ElegantElephant : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && CB(1)
			   && tmp.BelongsToClan("Pale Moon")
			   && tmp.bHasLimitBreak4)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				IncreasePowerByBattle(OwnerCard, 3000);
				EndEffect();
			});
		});
	}
}
