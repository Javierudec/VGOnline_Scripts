using UnityEngine;
using System.Collections;

public class DemonWorldCastleZweispeer : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(CB (1, delegate(Card c) { return c.BelongsToClan("Shadow Paladin"); })
			   && VanguardIs("Shadow Paladin"))
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
				return c.BelongsToClan("Shadow Paladin");
			});
		});
	}
}
