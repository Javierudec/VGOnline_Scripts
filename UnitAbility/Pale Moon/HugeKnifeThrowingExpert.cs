using UnityEngine;
using System.Collections;

public class HugeKnifeThrowingExpert : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call_NotMe)
		{
			if(ownerEffect.grade == 3
			   && ownerEffect.BelongsToClan("Pale Moon"))
			{
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
}
