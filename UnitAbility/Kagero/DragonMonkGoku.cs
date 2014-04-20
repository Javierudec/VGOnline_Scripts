using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC):When this unit's drive check reveals a grade 3 
 * «Kagero», choose an opponent's grade 1 or less rear-guard, and retire it.
 */

public class DragonMonkGoku : UnitObject {
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC()
			   && Game.DriveCard.BelongsToClan("Kagero")
			   && Game.DriveCard.grade == 3
			   && NumEnemyUnits(delegate(Card c) { return c.grade <= 1; }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's grade 1 or less rear-guards.", 1, true,
			delegate {
				RetireEnemyUnit(EnemyUnit);
			},
			delegate {
				return EnemyUnit.grade <= 1;
			},
			delegate {

			});
		});
	}
}
