using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Choose another of your rear-guards with "Eradicator" in 
 * its card name, and put it into your soul] When this unit is placed 
 * on (VC) or (RC), if you have a «Narukami» vanguard, you may pay the cost. 
 * If you do, choose one of your opponent's rear-guards in the front row, and retire it.
 */

public class FiendishSwordEradicatorChoOu : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(NumUnits(delegate(Card c) { return c.name.Contains("Eradicator") && c != OwnerCard; }) > 0
			   && VanguardIs("Narukami"))
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
		DelayUpdate (delegate {
			SelectUnit("Choose another of your rear-guards with \"Eradicator\" in its card name.", 1, false,
			delegate {
				MoveToSoul(Unit);
			}, 
			delegate {
				return Unit.name.Contains("Eradicator");
			},
			delegate {
				if(NumEnemyUnits(delegate(Card c) { return IsFrontRow(c); }) > 0)
				{
					SelectEnemyUnit("Choose one of your opponent's rear-guards in the front row.", 1, true,
					                delegate {
						RetireEnemyUnit(EnemyUnit);
					},
					delegate {
						return IsFrontRow(EnemyUnit);
					},
					delegate {
						
					});
				}
				else
				{
					EndEffect();
				}
			});
		});
	}
}
