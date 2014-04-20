using UnityEngine;
using System.Collections;

public class LiberatorBurningBlow : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC ()
			   && Game.DriveCard.BelongsToClan("Gold Paladin"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}
}
