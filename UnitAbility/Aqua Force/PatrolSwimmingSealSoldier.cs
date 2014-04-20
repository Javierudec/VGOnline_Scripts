using UnityEngine;
using System.Collections;

public class PatrolSwimmingSealSoldier : UnitObject {
	public override int Act ()
	{
		if(RC()
		   && OwnerCard.IsStand()
		   && NumUnits (delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Aqua Force"); }, true) > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			RestUnit(OwnerCard);
			SelectUnit("Choose another of your \"Aqua Force\"", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 2000);
			},
			delegate {
				return Unit != OwnerCard && Unit.BelongsToClan("Aqua Force");
			},
			delegate {

			}, true);
		});
	}
}


