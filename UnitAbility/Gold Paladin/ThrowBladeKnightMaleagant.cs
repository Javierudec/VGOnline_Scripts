using UnityEngine;
using System.Collections;

public class ThrowBladeKnightMaleagant : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(CanSoulBlast(2)
			   && VanguardIs("Gold Paladin")
			   && NumUnitsDamage(delegate(Card c) { return !c.IsFaceup(); }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulBlast(2);
		});

		SoulBlastUpdate(delegate {
			int n = min (2, NumUnitsDamage(delegate(Card c) { return !c.IsFaceup(); }));
			Flipup(n,
			delegate {
				EndEffect();
			});
		});
	}
}
