using UnityEngine;
using System.Collections;

public class LotusDruid : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(NumUnits (delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Neo Nectar"); }, true) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit ("Choose another of your \"Neo Nectar\".", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 2000);
			},
			delegate {
				return Unit != OwnerCard && Unit.BelongsToClan("Neo Nectar");
			},
			delegate {

			}, true);
		});
	}
}
