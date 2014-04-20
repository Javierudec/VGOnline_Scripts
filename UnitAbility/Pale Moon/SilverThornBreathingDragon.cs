using UnityEngine;
using System.Collections;

public class SilverThornBreathingDragon : UnitObject {
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
