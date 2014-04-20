using UnityEngine;
using System.Collections;

public class BeastDeityDesertGator : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC ()
			   && GetVanguard().name.Contains("Beast Deity"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
