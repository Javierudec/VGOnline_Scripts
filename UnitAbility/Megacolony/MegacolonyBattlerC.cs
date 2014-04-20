using UnityEngine;
using System.Collections;

/*
 * AUTO: When another «Megacolony» rides this unit, you may call this 
 * card to Rear-guard Circle.
 * 
 * AUTO【R】: [Counter Blast (1) & Put this unit into your soul] When an 
 * attack hits during the battle that this unit boosted a «Megacolony», you 
 * may pay the cost. If you do, choose one of your opponent's rear-
 * guards, and that unit cannot Stand during your opponent's next stand phase.
 */

public class MegacolonyBattlerC : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			Forerunner("Megacolony");	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(tmp != null && tmp.BelongsToClan("Megacolony") && CB (1) && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
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
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
				delegate {
					CantStandUntilNextTurn(EnemyUnit);
				},
				delegate {
					return true;
				},
				delegate {
					
				});
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectEnemyUnit_Pointer();
	}
}
