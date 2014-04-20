using UnityEngine;
using System.Collections;

public class CertainKillEradicatorOuei : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride_NotMe)
		{
			if(RC ()
			   && ownerEffect.grade == 3
			   && ownerEffect.BelongsToClan("Narukami")
			   && NumEnemyUnits(delegate(Card c) { return IsFrontRow(c); }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectUnit ("Choose one of your opponent's rear-guards in the front row.", 1, true,
			delegate {
				RetireEnemyUnit(EnemyUnit);
			},
			delegate {
				return IsFrontRow(EnemyUnit);
			},
			delegate {

			});
		});
	}
}
