using UnityEngine;
using System.Collections;

public class SuppressionEradicatorDokkasei : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(VanguardIs ("Narukami")
			   && OwnerCard.IsStand())
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			RestUnit(OwnerCard);
			int n = NumEnemyUnits(delegate(Card c) { return true; });
			SelectEnemyUnit("Choose " + n + " of your opponent's rear-guards.", n, true,
			delegate {
				CantInterceptUntilEndTurn(EnemyUnit);
			},
			delegate {
				return true;
			},
			delegate {

			});
		});
	}
}
