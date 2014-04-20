using UnityEngine;
using System.Collections;

/*
 * [ACT](RC):[Counter Blast (1)] If you have a «Nova Grappler» 
 * vanguard, choose up to two of your other rear-guards with "Death 
 * Army" in its card name, and [Stand] them. This ability cannot be used 
 * for the rest of that turn.
 */

public class DeathArmyBishop : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.EndBattle)
		{
			UnsetBool(1);			
		}
	}
	
	public override int Act ()
	{
		if(RC () && CB (1) && VanguardIs("Nova Grappler") &&
		   NumUnits(delegate(Card c) { return c.name.Contains("Death Army") && !c.IsStand() && c != OwnerCard; }) > 0 &&
		   !GetBool(1))
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				int num = min(2, NumUnits(delegate(Card c) { return c.name.Contains("Death Army") && !c.IsStand() && c != OwnerCard;}));
				SelectUnit("Choose " + num + " of your other rear-guards with \"Death Army\" in its card name.", num, true,
				delegate {
					StandUnit(Unit);
				},
				delegate {
					return Unit != OwnerCard && !Unit.IsStand() && Unit.name.Contains("Death Army");
				},
				delegate {
					SetBool(1);
				});
			});
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
		CounterBlast_Pointer();
	}
}
