using UnityEngine;
using System.Collections;

public class JackinPumpkin : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(CB(1, delegate(Card c) { return c.BelongsToClan("Neo Nectar"); })
			   && VanguardIs("Neo Nectar"))
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
				return c.BelongsToClan("Neo Nectar");
			});
		});
	}
}
