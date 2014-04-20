using UnityEngine;
using System.Collections;

public class DimensionalRoboGocannon : UnitObject {
	public override int Act ()
	{
		if(RC()
		   && NumUnits(delegate(Card c) { return c.name.Contains("Dimensional Robo") && c != OwnerCard; }) > 0
		   && GetVanguard().name.Contains("Daiyusha"))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectUnit ("Choose another of your rear-guards with \"Dimensional Robo\" in its card name.", 1, true,
			delegate{
				MoveToSoul(Unit);
			},
			delegate {
				return Unit.name.Contains("Dimensional Robo");
			},
			delegate {
				IncreasePowerAndCriticalByTurn(GetVanguard(), 0, 1);
			});
		});
	}
}
