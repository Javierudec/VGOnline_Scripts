using UnityEngine;
using System.Collections;

public class EyeOfDestructionZeal : UnitObject {
	public override void Cont()
	{
		if(VC () 
		   && IsInSoul(CardIdentifier.LARVA_BEAST__ZEAL))
		{
			AddContPower(1000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.DEVOURER_OF_PLANETS__ZEAL && IsInSoul(CardIdentifier.LARVA_BEAST__ZEAL))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			IncreaseEnemyPowerByTurn(GetEnemyVanguard(), -3000);
			EndEffect();
		});
	}
}
