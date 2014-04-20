using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, 
 * you may call this unit to (RC))
 * 
 * [AUTO](RC):When this unit boosts a «Spike Brothers» normal unit 
 * rear-guard, you may give the boosted unit [Power]+3000 until end of 
 * that battle. If you give it [Power]+3000, put the unit at the bottom 
 * of your deck at the end of that battle.
 */

public class ReignOfTerrorThermidor : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Spike Brothers");
		}
		else if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && tmp.BelongsToClan("Spike Brothers")
			   && !tmp.IsVanguard()
			   && tmp.GetTriggerType() == TriggerIcon.NONE)
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

		DelayUpdate(delegate {
			IncreasePowerByBattle(OwnerCard.boostedUnit, 3000);
			OwnerCard.boostedUnit.unitAbilities.AddUnitObject(new ReignOfTerrorThermidorEXT());
			EndEffect();
		});
	}
}

public class ReignOfTerrorThermidorEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndBattle)
		{
			FromFieldToDeck(OwnerCard, true);
		}
	}
}
