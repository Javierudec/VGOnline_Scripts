using UnityEngine;
using System.Collections;

public class DemonWorldCastleZerschlagen : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride_NotMe)
		{
			if(RC ()
			   && ownerEffect.grade == 3
			   && ownerEffect.BelongsToClan("Shadow Paladin"))
			{
				IncreasePowerByTurn(OwnerCard, 10000);
			}
		}
	}
}
