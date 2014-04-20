using UnityEngine;
using System.Collections;

public class DominateDriveDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC()
			   && GetVanguard().name.Contains("Dauntless"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
