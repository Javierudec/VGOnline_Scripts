using UnityEngine;
using System.Collections;

public class DestructionStarvaderTungsten : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC ()
			   && GetDefensor().IsVanguard()
			   && NumEnemyUnits(delegate(Card c) { return c.IsLocked(); }, true, true) > 0)
			{
				IncreasePowerByBattle(OwnerCard, 4000);
			}
		}
	}
}
