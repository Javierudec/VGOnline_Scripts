using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (1)] When this unit attacks, you may pay the cost. If you do, this unit gets [Power]+3000 until end of that battle.
 */

public class RaidStarvaderFrancium : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(CB(1))
			{
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();	
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				IncreasePowerByBattle(OwnerCard, 3000);	
				EndEffect();
				ConfirmAttack();
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
