using UnityEngine;
using System.Collections;

public class CatastropheStinger : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride_NotMe)
		{
			if(RC ()
			   && ownerEffect.grade == 3
			   && ownerEffect.BelongsToClan("Link Joker"))
			{
				IncreasePowerByTurn(OwnerCard, 10000);
			}
		}
	}
}
