using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Soul Blast (1)] When this unit is returned to your hand from (RC), 
 * you may pay the cost. If you do, choose another of your «Bermuda 
 * Triangle», and that unit gets [Power]+4000 until end of turn.
 */

public class PRISMMiracleIrish : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.HandFromRear)
		{
			if(CanSoulBlast(1) && NumUnits(delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Bermuda Triangle"); }, true) > 0)
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
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			SelectUnit("Choose another of your \"Bermuda Triangle\".", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 4000);
			},
			delegate {
				return Unit != OwnerCard && Unit.BelongsToClan("Bermuda Triangle");
			},
			delegate {
				
			}, true);
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
	}
}
