using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Soul Blast (1)] When this unit boosts a unit named "Battle Sister, Cookie", you may pay the cost. 
 * If you do, the boosted unit gets [Power]+5000 until end of that battle.
 */

public class BattleSisterCream : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(tmp != null && RC () && tmp.cardID == CardIdentifier.BATTLE_SISTER__COOKIE && CanSoulBlast(1))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard.boostedUnit, 5000);
			EndEffect();
		});
	}
}
