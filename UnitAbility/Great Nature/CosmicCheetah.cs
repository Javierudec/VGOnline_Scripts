using UnityEngine;
using System.Collections;

public class CosmicCheetah : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(HandSize() < Game.enemyHand.Size())
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
