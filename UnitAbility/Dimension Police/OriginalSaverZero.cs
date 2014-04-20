using UnityEngine;
using System.Collections;

public class OriginalSaverZero : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Dimension Police")
			   && LimitBreak(4))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			Card tmp = OwnerCard.IsBoostedBy;
			if(VC()
			   && tmp.BelongsToClan("Dimension Police"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			IncreasePowerByTurn(GetVanguard(), 10000);
			IncreaseEnemyPowerByTurn(GetEnemyVanguard(), -5000);
			EndEffect();
		});
	}
}
