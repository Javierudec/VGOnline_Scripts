using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or 
 * more damage):When this unit's drive check reveals a grade 3 «Tachikaze», 
 * choose one of your rear-guards, retire it, and this unit gets [Power]+10000 
 * until end of that battle.
 * 
 * [AUTO](VC):When this unit is boosted by a «Tachikaze», this unit gets 
 * [Power]+3000 until end of that battle.
 */

public class RavenousDragonBattlerex : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC ()
			   && LimitBreak(4)
			   && Game.DriveCard.grade == 3
			   && Game.DriveCard.BelongsToClan("Tachikaze"))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			Card tmp = OwnerCard.IsBoostedBy;
			if(VC ()
			   && tmp.BelongsToClan("Tachikaze"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(NumUnits(delegate(Card c) { return true; }) > 0)
			{
				SelectUnit("Choose one of your rear-guards.", 1, true,
				delegate {
					RetireUnit(Unit);
				},
				delegate {
					return true;
				},
				delegate {
					IncreasePowerByBattle(OwnerCard, 10000);
				});
			}
			else
			{
				IncreasePowerByBattle(OwnerCard, 10000);
				EndEffect();
			}
		});
	}
}
