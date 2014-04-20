using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (1)-«Bermuda Triangle»] When this unit 
 * attacks, if you have a «Bermuda Triangle» vanguard, you may pay the 
 * cost. If you do, this unit gets [Power]+4000 until end of that battle.
 */

public class PRISMSmileScotia : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VanguardIs("Bermuda Triangle") && CB (1, delegate(Card c) { return c.BelongsToClan("Bermuda Triangle"); }))
			{
				DisplayConfirmationWindow();
			}
			else
			{
				ConfirmAttack();	
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
			CounterBlast(1, 
			delegate {
				IncreasePowerByBattle(OwnerCard, 4000);
				EndEffect();
				ConfirmAttack();
			},
			delegate(Card c) {
				return c.BelongsToClan("Bermuda Triangle");
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
