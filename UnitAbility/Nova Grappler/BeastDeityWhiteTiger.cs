using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When another «Nova Grappler» rides this unit, you may call 
 * this card to (RC).
 * [AUTO](RC):[Counter Blast (1) & Put this unit into your soul] When an 
 * attack hits a vanguard during the battle that this unit boosted a «Nova 
 * Grappler», you may pay the cost. If you do, choose one of your 
 * «Nova Grappler» rear-guards with "Beast Deity" in its card name, and 
 * [Stand] it.
 */

public class BeastDeityWhiteTiger : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			Forerunner("Nova Grappler");	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(tmp != null && tmp.BelongsToClan("Nova Grappler") && CB (1))
			{
				if(NumUnits(delegate(Card c) { return c != OwnerCard && c.name.Contains("Beast Deity") && !c.IsStand(); }) > 0)
				{
					SetBool(1);
					DisplayConfirmationWindow();	
				}
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
	
	public override void Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			CounterBlast(1,
			delegate {
				SelectUnit("Choose one of your \"Nova Grappler\" with \"Beast Deity\" in its card name.", 1, true,
				delegate {
					StandUnit(Unit);	
				},
				delegate {
					return !Unit.IsStand() && Unit.BelongsToClan("Nova Grappler") && Unit.name.Contains("Beast Deity");
				},
				delegate {
					
				});
			});
		});
	}

	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectUnit_Pointer();
	}
}

