using UnityEngine;
using System.Collections;

public class StealthFiendMashiromomen : UnitObject {
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
			if(NumUnits (delegate(Card c) { return c.BelongsToClan("Nubatama"); }, true) > 0)
			{
				SelectUnit ("Choose one of your \"Nubatama\".", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 3000);
				},
				delegate {
					return Unit.BelongsToClan("Nubatama");
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
