using UnityEngine;
using System.Collections;

public class HomingEradicatorRochisin : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(RC ()
			   && GetVanguard().name.Contains("Eradicator"))
			{
				IncreasePowerByTurn(OwnerCard, 5000);
			}
		}
	}
}
