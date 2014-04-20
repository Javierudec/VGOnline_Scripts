using UnityEngine;
using System.Collections;

public class SpaceDragonDogurumadora : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && LimitBreak(4)
			   && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 5000);
			}

			if(RC ()
			   && GetDefensor().IsVanguard()
			   && VanguardIs("Dimension Police"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}
}
