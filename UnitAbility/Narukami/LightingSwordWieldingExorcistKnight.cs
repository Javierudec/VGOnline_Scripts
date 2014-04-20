using UnityEngine;
using System.Collections;

public class LightingSwordWieldingExorcistKnight : UnitObject {
	public override void Cont()
	{
		if(RC ())
		{
			AddContPower(-4000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Attacking)
		{
			if(VanguardIs("Narukami"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
}
