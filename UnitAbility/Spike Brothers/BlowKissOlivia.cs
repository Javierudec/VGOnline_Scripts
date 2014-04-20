using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Soul Blast (2)] When this unit's attack hits a vanguard, 
 * if you have a «Spike Brothers» vanguard, you may pay the cost. If you 
 * do, choose one of your opponent's rear-guard in the front row, retire it,
 * and put this unit on the bottom of your deck.
 */

public class BlowKissOlivia : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(RC ()
			   && CanSoulBlast(2)
			   && GetDefensor().IsVanguard()
			   && VanguardIs("Spike Brothers")
			   && NumEnemyUnits(delegate(Card c) { return IsFrontRow(c); }) > 0)
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
			SoulBlast(2);
		});

		SoulBlastUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's rear-guards in the front row.", 1, true,
			delegate {
				RetireEnemyUnit(EnemyUnit);
			},
			delegate {
				return IsFrontRow(EnemyUnit);
			},
			delegate {
				FromFieldToDeck(OwnerCard, true);
			});
		});
	}
}
