using UnityEngine;
using System.Collections;

public class MythGuardFomalhaut : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC ()
			   && Game.DriveCard.BelongsToClan("Genesis"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}
}
