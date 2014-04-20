using UnityEngine;
using System.Collections;

public class BattleSirenMarika : UnitObject {
	public override int Act ()
	{
		if(RC())
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			if(NumUnits(delegate(Card c) { return c.BelongsToClan("Aqua Force"); }, true) > 0)
			{
				SelectUnit ("Choose one of your \"Aqua Force\".", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 3000);
				},
				delegate {
					return Unit.BelongsToClan("Aqua Force");
				},
				delegate {

				}, true);
			}
			else
			{
				EndEffect();
			}
		});
	}
}
