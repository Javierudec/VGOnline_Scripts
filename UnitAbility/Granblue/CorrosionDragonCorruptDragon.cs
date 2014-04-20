using UnityEngine;
using System.Collections;

public class CorrosionDragonCorruptDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.CallFromDrop)
		{
			if(VanguardIs("Granblue"))
			{
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
}
