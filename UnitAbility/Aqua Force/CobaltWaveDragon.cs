using UnityEngine;
using System.Collections;

public class CobaltWaveDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking_NotMe)
		{
			if(VC()
			   && LimitBreak(4)
			   && GetDefensor().IsVanguard()
			   && !ownerEffect.IsVanguard()
			   && Game.numBattle >= 3)
			{
				IncreasePowerAndCriticalByTurn(OwnerCard, 2000, 1);
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC ()
			   && GetDefensor().IsVanguard()
			   && Game.numBattle >= 4)
			{
				IncreasePowerByBattle(OwnerCard, 5000);
			}
		}
	}
}
