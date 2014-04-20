using UnityEngine;
using System.Collections;

public class PoisonJuggler : UnitObject {
	public override int Act()
	{
		if(RC ())
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectUnit("Choose one of your \"Pale Moon\"", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 3000);
			},
			delegate {
				return Unit.BelongsToClan("Pale Moon");
			},
			delegate {

			}, true);
		});
	}
}
