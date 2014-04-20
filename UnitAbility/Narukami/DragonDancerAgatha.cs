using UnityEngine;
using System.Collections;

public class DragonDancerAgatha : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(VanguardIs("Narukami")
			   && CanSoulBlast(1)
			   && NumUnits (delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Narukami"); }, true) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulBlast(1);
		});

		SoulBlastUpdate(delegate {
			SelectUnit ("Choose another of your \"Narukami\".", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 3000);
			},
			delegate {
				return Unit != OwnerCard && Unit.BelongsToClan("Narukami");
			},
			delegate {

			}, true);
		});
	}
}
