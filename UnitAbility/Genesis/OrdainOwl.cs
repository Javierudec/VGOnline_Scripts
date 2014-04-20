using UnityEngine;
using System.Collections;

public class OrdainOwl : UnitObject {
	public override int Act ()
	{
		if(RC ()
		   && NumUnitsDamage(delegate(Card c) { return c.grade == 3 && c.name.Contains("Regalia"); }) > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(VanguardIs("Genesis")
			   && NumUnits (delegate(Card c) { return c.name.Contains("Regalia") && c.grade == 3; }, true) > 0)
			{
				SelectUnit ("Choose one of your grade 3 units with \"Regalia\" in its card name.", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 5000);
				},
				delegate {
					return Unit.name.Contains("Regalia") && Unit.grade == 3;
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
