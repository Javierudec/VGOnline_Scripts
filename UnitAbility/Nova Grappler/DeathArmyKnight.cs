using UnityEngine;
using System.Collections;

/*
 * [AUTO]:During your main phase, when this unit is placed on (RC), if 
 * you have a «Nova Grappler» vanguard, choose up to two of your other 
 * rear-guards with "Death Army" in its card name, and [Stand] them.
 */

public class DeathArmyKnight : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(CurrentPhaseIs(GamePhase.MAIN_PHASE) &&
			   VanguardIs("Nova Grappler") &&
			   NumUnits(delegate(Card c) { return c != OwnerCard && c.name.Contains("Death Army") && !c.IsStand(); }) > 0)
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
		DelayUpdate(delegate {
			int num = min (2, NumUnits(delegate(Card c) { return c != OwnerCard && c.name.Contains("Death Army") && !c.IsStand(); }));
			SelectUnit("Choose " + num + " of your other rear-guards with \"Death Army\" in its card name.", 1, true,
			delegate {
				StandUnit(Unit);	
			},
			delegate {
				return Unit != OwnerCard && !Unit.IsStand() && Unit.name.Contains("Death Army");
			},
			delegate {
				
			});
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
	}
}
