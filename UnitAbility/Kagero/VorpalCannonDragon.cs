using UnityEngine;
using System.Collections;

public class VorpalCannonDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 5000);
			}
		}
		else if(cs == CardState.Ride)
		{
			if(CB(2)
			   && NumEnemyUnits(delegate(Card c) { return c.grade <= 2; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SelectEnemyUnit("Choose one of your opponent's grade 2 or less rear-guards.", 1, true,
				delegate {
					RetireEnemyUnit(EnemyUnit);
				},
				delegate {
					return EnemyUnit.grade <= 2;
				},
				delegate {

				});
			});
		});
	}
}
