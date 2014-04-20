using UnityEngine;
using System.Collections;

public class SteelbloodedEradicatorShuki : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(GetVanguard().name.Contains("Eradicator"))
			{
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
}
