using UnityEngine;
using System.Collections;

public class SilverThornRisingDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC ()
			   && GetVanguard().name.Contains("Silver Thorn"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
