using UnityEngine;
using System.Collections;

public class DonnerSchlag : UnitObject {
	public override void Cont()
	{
		if(GetVanguard().cardID != CardIdentifier.BLASTER_DARK && GetVanguard().cardID != CardIdentifier.PHANTOM_BLASTER_DRAGON)
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
