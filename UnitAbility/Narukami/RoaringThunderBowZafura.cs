using UnityEngine;
using System.Collections;

public class RoaringThunderBowZafura : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(GetDefensor ().IsVanguard()
			   && VanguardIs("Narukami")
			   && NumUnitsDamage(delegate(Card c) { return !c.IsFaceup(); }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			Flipup(1,
			delegate {
				EndEffect();
			});
		});
	}
}
