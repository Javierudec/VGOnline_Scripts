using UnityEngine;
using System.Collections;

public class DeathArmyCommander : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck_NotMe)
		{
			if(RC()
			   && GetAttacker().IsVanguard()
			   && Game.DriveCard.grade == 3
			   && Game.DriveCard.BelongsToClan("Nova Grappler"))
			{
				StandUnit(OwnerCard);
			}
		}
	}
}
