using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))
 * [ACT](RC):[Put this unit into your soul] Choose up to one of your «Gold Paladin», and that unit gets [Power]+3000 until end of turn.
 */

public class StrongholdOfTheBlackChainsHoel : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Gold Paladin"))
			{
				SetBool(1);
				Forerunner("Gold Paladin");
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
			if(NumUnits(delegate(Card c) { return c.BelongsToClan("Gold Paladin"); }, true) > 0)
			{
				SelectUnit("Choose one of your \"Gold Paladin\" units.", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 3000);
				},
				delegate {
					return Unit.BelongsToClan("Gold Paladin");
				},
				delegate {
					
				}, true);
			}
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
	}
}
