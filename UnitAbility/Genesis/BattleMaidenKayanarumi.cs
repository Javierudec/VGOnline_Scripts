using UnityEngine;
using System.Collections;

public class BattleMaidenKayanarumi : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(NumUnits (delegate(Card c) { return true; }) > NumEnemyUnits(delegate(Card c) { return true; }))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
