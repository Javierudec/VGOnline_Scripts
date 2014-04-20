using UnityEngine;
using System.Collections;

public class PlasmaScimitarDragoon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride_NotMe)
		{
			if(RC ()
			   && ownerEffect.grade == 3
			   && ownerEffect.BelongsToClan("Narukami"))
			{
				IncreasePowerByTurn(OwnerCard, 10000);			
			}
		}
	}
}
