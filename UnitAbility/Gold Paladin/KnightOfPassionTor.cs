using UnityEngine;
using System.Collections;

public class KnightOfPassionTor : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC ()
			   && GetVanguard().name.Contains("Ezel"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
