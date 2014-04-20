using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, 
 * you may call this unit to (RC))
 * 
 * [ACT](RC):[Put this unit into your soul] Choose up to one of your «Narukami», 
 * and that unit gets [Power]+3000 until end of turn.
 */

public class FlagOfRaijinCorposant : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Narukami"))
			{
				SetBool(1);
				Forerunner("Narukami");
			}
		}
	}

	public override int Act ()
	{
		if(RC ())
		{
			return 1;
		}

		return 0;
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
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			if(NumUnits(delegate(Card c) { return c.BelongsToClan("Narukami"); }, true) > 0)
			{
				SelectUnit("Choose one of your \"Narukami\".", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 3000);
				},
				delegate {
					return Unit.BelongsToClan("Narukami");
				},
				delegate {

				}, true);
			}
			else
			{
				EndEffect();
			}
		});
	}
}
