using UnityEngine;
using System.Collections;

public class Ironcutter : UnitObject {
	public override void Cont()
	{
		if(GetVanguard().cardID != CardIdentifier.EVIL_ARMOR_GENERAL__GIRAFFA && GetVanguard().cardID != CardIdentifier.ELITE_MUTANT__GIRAFFA)
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
