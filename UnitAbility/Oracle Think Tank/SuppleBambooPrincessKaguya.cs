using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))
 * [ACT](RC):[Put this unit into your soul] Choose up to one of your «Oracle Think Tank»,
 * and that unit gets [Power]+3000 until end of turn.
 */ 

public class SuppleBambooPrincessKaguya : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Oracle Think Tank");	
		}
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
	
	public override int Act ()
	{
		if(RC () && NumUnits(delegate(Card c) {
			return c != OwnerCard && c.BelongsToClan("Oracle Think Tank");
		}, true) > 0)
		{
			return 1;
		}
		
		return 0;
	}
	
	public override void Update ()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectUnit("Choose one of your \"Oracle Think Tank\" units", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 3000);
			},
			delegate {
				return Unit.BelongsToClan("Oracle Think Tank");
			},
			delegate {
				
			}, true);
		});
	}
	
	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
	}
}
