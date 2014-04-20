using UnityEngine;
using System.Collections;

public class RedPencilRhino : UnitObject {
	public override void Cont()
	{
		if(GetVanguard().cardID != CardIdentifier.LAW_OFFICIAL__LOX &&
		   GetVanguard().cardID != CardIdentifier.GUARDIAN_OF_TRUTH__LOX)
		{
			AddContPower(5000);	
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
