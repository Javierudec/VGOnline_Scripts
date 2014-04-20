using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is placed on (RC), choose another of your
 * «Kagero», and that unit gets [Power]+2000 until end of turn.
 */

public class GrapeshotWyvern : UnitObject {
	public string clan = "Kagero";
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(NumUnits(delegate(Card c) { return c != OwnerCard && c.BelongsToClan(clan); }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your \"" + clan + "\".", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 2000);
			},
			delegate {
				return Unit != OwnerCard && Unit.BelongsToClan(clan);
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
