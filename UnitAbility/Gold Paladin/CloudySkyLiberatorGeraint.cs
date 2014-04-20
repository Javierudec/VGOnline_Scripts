using UnityEngine;
using System.Collections;

public class CloudySkyLiberatorGeraint : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.CallFromDeck_NotMe)
		{
			if(RC()
			   && ownerEffect.BelongsToClan("Gold Paladin")
			   && GetVanguard().name.Contains("Liberator"))
			{
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
}
