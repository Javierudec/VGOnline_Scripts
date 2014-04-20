using UnityEngine;
using System.Collections;

public class Eisenkugel : UnitObject {
	public override void Cont()
	{
		if(GetVanguard().cardID != CardIdentifier.BLAUKLUGER && GetVanguard().cardID != CardIdentifier.STERN_BLAUKLUGER)
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
