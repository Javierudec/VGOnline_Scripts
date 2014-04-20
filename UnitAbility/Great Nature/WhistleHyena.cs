using UnityEngine;
using System.Collections;

public class WhistleHyena : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(CB(1, delegate(Card c) { return c.BelongsToClan("Great Nature"); })
			   && VanguardIs("Great Nature"))
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				IncreasePowerByBattle(OwnerCard, 4000);
				EndEffect();
			},
			delegate(Card c) {
				return c.BelongsToClan("Great Nature");
			});
		});
	}
}
