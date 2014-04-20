using UnityEngine;
using System.Collections;

public class NumberOfTerror : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call_NotMe)
		{
			if(ownerEffect.grade == 3
			   && ownerEffect.BelongsToClan("Dark Irregulars"))
			{
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
}
