using UnityEngine;
using System.Collections;

public class LightingAxeWieldingExorcistKnight : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC ()
			   && GetVanguard().name.Contains("Dungaree"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
