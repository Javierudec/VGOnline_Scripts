using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When another «Nova Grappler» rides this unit, you may call 
 * this card to (RC).
 * 
 * [ACT](RC):[Choose another of your rear-guards with "Death Army" in 
 * its card name, and [Rest] it] If you have a «Nova Grappler» vanguard, 
 * this unit gets [Power]+2000 until end of turn.
 */

public class DeathArmyPawn : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Nova Grappler"))
			{
				SetBool(1);
				Forerunner("Nova Grappler");
			}
		}
	}
	
	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}
	
	public override void Active()
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
		if(RC () && VanguardIs("Nova Grappler") && NumUnits(delegate(Card c) { return c.name.Contains("Death Army") && !c.IsStand() && c != OwnerCard; }) > 0)
		{
			return 1;
		}
		
		return 0;
	}
	
	public override void Update ()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			SelectUnit("Choose another of your rear-guards with \"Death Army\" in its card name,", 1, true,
			delegate {
				RestUnit(Unit);
			},
			delegate {
				return Unit != OwnerCard && Unit.name.Contains("Death Army") && !Unit.IsStand();
			},
			delegate {
				IncreasePowerByTurn(OwnerCard, 2000);
			});
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
	}
}
