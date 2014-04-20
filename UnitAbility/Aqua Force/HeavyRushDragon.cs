using UnityEngine;
using System.Collections;

public class HeavyRushDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VanguardIs("Aqua Force")
			   && Game.numBattle == 2)
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
