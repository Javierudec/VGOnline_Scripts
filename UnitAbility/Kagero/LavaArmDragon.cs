using UnityEngine;
using System.Collections;

public class LavaArmDragon : UnitObject {
	public override void Cont()
	{
		if(GetVanguard().cardID != CardIdentifier.AMBER_DRAGON__ECLIPSE && GetVanguard().cardID != CardIdentifier.AMBER_DRAGON__DUSK)
		{
			AddContPower(-5000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Attacking)
		{
			IncreasePowerByBattle(OwnerCard, 2000);
		}
	}
}
