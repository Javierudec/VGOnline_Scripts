using UnityEngine;
using System.Collections;

public class GreenAxeKnightTaliesyn : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride_NotMe)
		{
			if(RC ()
			   && ownerEffect.grade == 3
			   && ownerEffect.BelongsToClan("Gold Paladin"))
			{
				IncreasePowerByTurn(OwnerCard, 10000);
			}
		}
	}
}
