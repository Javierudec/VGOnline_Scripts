using UnityEngine;
using System.Collections;

public class ArborosDragonSephirot : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && LimitBreak(4))
		{
			if(IsPlayerTurn())
			{
				ForEachUnitOnField(delegate(Card c) {
					if(NumUnits (delegate(Card d) { return c != d && c.cardID == d.cardID; }, true) > 0)
					{
						c.unitAbilities.SetPower(3000);
					}
				});
			}
		}

		if(VC ()
		   && IsInSoul(CardIdentifier.ARBOROS_DRAGON__TIMBER))
		{
			AddContPower(1000);
		}
	}
}
