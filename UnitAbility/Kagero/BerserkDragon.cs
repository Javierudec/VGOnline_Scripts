using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (2)] When this unit is placed on (VC) or (RC),
 * if you have a «Kagero» vanguard, you may pay the cost. If you do, 
 * choose an opponent's grade 2 or less rear-guard, and retire it.
 */

public class BerserkDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB(2) 
			   && VanguardIs("Kagero")
			   && NumEnemyUnits(delegate(Card c) { return c.grade <= 2; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active ()
	{
		ShowAndDelay();
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
