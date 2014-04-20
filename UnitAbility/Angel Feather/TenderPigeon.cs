using UnityEngine;
using System.Collections;

public class TenderPigeon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(NumUnits (delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Angel Feather"); }, true) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit ("Choose another of your \"Angel Feather\" rear-guards.", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 2000);
			},
			delegate {
				return Unit.BelongsToClan("Angel Feather") && Unit != OwnerCard;
			},
			delegate {

			}, true);
		});
	}
}
