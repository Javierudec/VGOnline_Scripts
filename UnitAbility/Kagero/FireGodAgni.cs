using UnityEngine;
using System.Collections;

public class FireGodAgni : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && GetDefensor().IsVanguard()
			   && GetDefensor().GetPower() >= 12000)
			{
				IncreasePowerByBattle(OwnerCard, 10000);
			}

			if(RC ()
			   && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}
}
