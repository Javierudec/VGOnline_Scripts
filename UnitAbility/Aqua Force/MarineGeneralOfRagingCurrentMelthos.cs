using UnityEngine;
using System.Collections;

public class MarineGeneralOfRagingCurrentMelthos : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard()
			   && VanguardIs("Aqua Force"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}
}
