using UnityEngine;
using System.Collections;

public class AmonsFollowerRonGeenlin : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC ()
			   && GetVanguard().name.Contains("Amon"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
