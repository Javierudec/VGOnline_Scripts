using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is placed on (RC), choose another of your 
 * «Royal Paladin», and that unit gets [Power]+2000 until end of turn.
 */

public class StarlightUnicorn : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(NumUnits (delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Royal Paladin"); }, true) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your \"Royal Paladin\".", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 2000);
			},
			delegate {
				return Unit.BelongsToClan("Royal Paladin") && Unit != OwnerCard;
			},
			delegate {

			}, true);
		});
	}
}
