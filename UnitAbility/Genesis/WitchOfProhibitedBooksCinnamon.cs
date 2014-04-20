using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, 
 * you may call this unit to (RC))
 * 
 * [AUTO](RC):[Put this unit into your soul] When an attack hits a 
 * vanguard during the battle that this unit boosted a grade 3 or
 * greater «Genesis», you may pay the cost. If you do, Soul Charge (2).
 */

public class WitchOfProhibitedBooksCinnamon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Genesis");
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC()
			   && GetDefensor ().IsVanguard()
			   && GetAttacker() == tmp
			   && tmp.grade >= 3
			   && tmp.BelongsToClan("Genesis")
			   && GetDeck ().Size() >= 2)
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Active ()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			ShowAndDelay();
		}
		else
		{
			Forerunner_Active();
		}
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate (delegate {
			SoulCharge(2);
		});

		SoulChargeUpdate(delegate {
			EndEffect();
		});
	}
}
