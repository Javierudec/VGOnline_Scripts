using UnityEngine;
using System.Collections;

public class StealthFiendMezuou : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && CB(1)
			   && tmp.BelongsToClan("Nubatama")
			   && tmp.bHasLimitBreak4)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				IncreasePowerByTurn(OwnerCard.boostedUnit, 3000);
				EndEffect();
			});
		});
	}
}
