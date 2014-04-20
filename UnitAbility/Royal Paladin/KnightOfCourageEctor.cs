using UnityEngine;
using System.Collections;

public class KnightOfCourageEctor : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC()
			   && Game.DriveCard.BelongsToClan("Royal Paladin"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}
}
