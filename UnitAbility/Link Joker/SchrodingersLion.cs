using UnityEngine;
using System.Collections;

public class SchrodingersLion : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard()
			   && VanguardIs("Link Joker"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}
}
