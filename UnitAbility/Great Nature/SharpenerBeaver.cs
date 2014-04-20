using UnityEngine;
using System.Collections;

/*
 * [AUTO]: When this unit is placed on (RC), 
 * choose another of your grade 3 «Great Nature», 
 * and that unit gets [Power]+3000 until end of turn.
 */

public class SharpenerBeaver : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(NumUnits(delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Great Nature") && c.grade == 3; }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your grade 3 \"Great Nature\".", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 3000);
			},
			delegate {
				return Unit != OwnerCard && Unit.BelongsToClan("Great Nature") && Unit.grade == 3;
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
