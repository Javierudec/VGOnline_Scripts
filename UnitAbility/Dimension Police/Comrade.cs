using UnityEngine;
using System.Collections;

public class Comrade : UnitObject {
	public override void Cont()
	{
		if(GetVanguard().cardID != CardIdentifier.ENIGMAN_WAVE &&
		   GetVanguard().cardID != CardIdentifier.ENIGMAN_STORM)
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
