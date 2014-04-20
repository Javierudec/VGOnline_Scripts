using UnityEngine;
using System.Collections;

public class SunriseUnicorn : UnitObject {
	public override int Act ()
	{
		if(RC ()
		   && OwnerCard.IsStand()
		   && NumUnits(delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Gold Paladin"); }, true) > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			RestUnit(OwnerCard);
			SelectUnit("Choose another of your \"Gold Paladin\".", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 2000);
			},
			delegate {
				return Unit != OwnerCard && Unit.BelongsToClan("Gold Paladin");
			},
			delegate {

			}, true);
		});
	}
}
