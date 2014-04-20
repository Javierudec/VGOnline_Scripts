using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (2)] When this unit is placed on (VC), you may 
 * pay the cost. If you do, choose one of your opponent's rear-guards, 
 * and retire it.
 * [AUTO]:[Counter Blast (2)] When this unit is placed on (RC), if you 
 * have a «Royal Paladin» vanguard, you may pay the cost. If you do,
 * choose one of your opponent's grade 2 or greater rear-guards, and retire it.
 */

public class BlasterBlade : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride)
		{
			if(CB (2) && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.Call)
		{
			if(CB(2) && VanguardIs("Royal Paladin") && NumEnemyUnits(delegate(Card c) { return c.grade >= 2; }) > 0)
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
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				CounterBlast(2,
				delegate {
					SelectEnemyUnit("Choose one of your grade 2 or greater opponent's rear-guards.", 1, true,
					delegate {
						RetireEnemyUnit(EnemyUnit);
					},
					delegate {
						return EnemyUnit.grade >= 2;
					},
					delegate {
						
					});
				});
			}
			else
			{
				CounterBlast(2,
				delegate {
					SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
					delegate {
						RetireEnemyUnit(EnemyUnit);
					},
					delegate {
						return true;
					},
					delegate {
						
					});
				});
			}
		});
	}
	
	public override void Pointer ()
	{
		SelectEnemyUnit_Pointer();
		CounterBlast_Pointer();
	}
}
