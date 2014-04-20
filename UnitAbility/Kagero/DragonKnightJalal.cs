using UnityEngine;
using System.Collections;

public class DragonKnightJalal : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC ()
			   && Game.DriveCard.BelongsToClan("Kagero"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}
}
