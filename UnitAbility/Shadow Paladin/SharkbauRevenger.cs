using UnityEngine;
using System.Collections;

public class SharkbauRevenger : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(NumUnits(delegate(Card c) { return c.bHasLimitBreak4; }, true) > 0)
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
