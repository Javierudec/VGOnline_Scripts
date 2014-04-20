using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC): When this unit attacks, if the number of rear-guards 
 * you have is less than your opponent's, this unit gets [Power]+3000 until 
 * end of that battle.
 */

public class ColibauRevenger : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(NumUnits(delegate(Card c) { return true; }) < NumEnemyUnits(delegate(Card c) { return true; }))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
		}
	}
}
