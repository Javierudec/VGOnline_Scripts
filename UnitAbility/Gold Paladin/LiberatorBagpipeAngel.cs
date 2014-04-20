using UnityEngine;
using System.Collections;

public class LiberatorBagpipeAngel : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.CallFromDeck)
		{
			StartEffect();
			ShowAndDelay();
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			int n = min (2, NumUnits(delegate(Card c) { return c.name.Contains("Liberator"); }, true));
			SelectUnit("Choose " + n + " of your units with \"Liberator\" in its card name.", n, true,
			delegate {
				IncreasePowerByTurn(Unit, 2000);
			},
			delegate {
				return Unit.name.Contains("Liberator");
			},
			delegate {

			}, true);
		});
	}
}
