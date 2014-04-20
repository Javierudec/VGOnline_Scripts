using UnityEngine;
using System.Collections;

public class AnalyticMonsterGigabolt : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC ()
			   && GetDefensor().IsVanguard()
			   && GetDefensor().GetPower() <= 8000)
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
