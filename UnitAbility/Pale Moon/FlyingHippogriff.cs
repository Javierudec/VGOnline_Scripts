using UnityEngine;
using System.Collections;

public class FlyingHippogriff : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(NumUnits (delegate(Card c) { return c.BelongsToClan("Pale Moon") && c.bHasLimitBreak4; }, true) > 0)
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
