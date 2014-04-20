using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (1)] When this unit is placed on (RC), you may pay 
 * the cost. If you do, choose another of your units with "Dimensional Robo" in 
 * its card name, and that unit gets [Power]+4000 until end of turn.
 */

public class DimensionalRoboDaidriller : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(CB(1) && NumUnits(delegate(Card c) { return c != OwnerCard && c.name.Contains("Dimensional Robo"); }, true) > 0)
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
			CounterBlast(1,
			delegate {
				SelectUnit("Choose another of your units with \"Dimensional Robo\" in its card name.", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 4000);
				},
				delegate {
					return Unit != OwnerCard && Unit.name.Contains("Dimensional Robo");
				},
				delegate {
					
				}, true);
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectUnit_Pointer();
	}
}
