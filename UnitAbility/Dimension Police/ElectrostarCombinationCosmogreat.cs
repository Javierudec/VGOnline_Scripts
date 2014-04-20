using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (2)] When this unit is placed on (RC), you may pay 
 * the cost. If you do, choose another of your «Dimension Police», and that 
 * unit gets [Power]+4000 until end of turn.
 */

public class ElectrostarCombinationCosmogreat : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(CB(2) && NumUnits(delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Dimension Police"); }, true) > 0)
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
			CounterBlast(2,
			delegate {
				SelectUnit("Choose another of your \"Dimension Police\".", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 4000);
				},
				delegate {
					return Unit != OwnerCard && Unit.BelongsToClan("Dimension Police");
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
