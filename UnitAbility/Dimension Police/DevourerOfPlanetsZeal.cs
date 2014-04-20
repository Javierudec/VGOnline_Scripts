using UnityEngine;
using System.Collections;

public class DevourerOfPlanetsZeal : UnitObject {
	public override void Cont()
	{
		if(VC () 
		   && IsInSoul(CardIdentifier.EYE_OF_DESTRUCTION__ZEAL))
		{
			AddContPower(1000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.GALACTIC_BEAST__ZEAL && 
			   IsInSoul(CardIdentifier.EYE_OF_DESTRUCTION__ZEAL))
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
