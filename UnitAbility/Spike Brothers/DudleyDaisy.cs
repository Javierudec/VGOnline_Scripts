using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (1)] During your battle phase, 
 * when this unit is placed on (RC), if you have a «Spike 
 * Brothers» vanguard, you may pay the cost. If you do, this 
 * unit gets [Power]+5000 until end of turn.
 */ 

public class DudleyDaisy : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(CurrentPhaseIs(GamePhase.ATTACK) && CB (1) && VanguardIs("Spike Brothers"))
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				IncreasePowerByTurn(OwnerCard, 5000);
				EndEffect();
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
