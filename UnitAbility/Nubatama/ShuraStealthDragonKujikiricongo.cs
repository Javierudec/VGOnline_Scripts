using UnityEngine;
using System.Collections;

public class ShuraStealthDragonKujikiricongo : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Nubatama")
			   && LimitBreak(4))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC ()
			   && Game.enemyHand.Size() <= 3)
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			IncreasePowerByTurn(GetVanguard(), 10000);
			EnemyHasToDiscardOneCard();
			SetBool(1);
		});
	}

	public override void EndEvent ()
	{
		if(GetBool (1))
		{
			UnsetBool(1);
			OpponentBindHandCardFaceDownReturnEndTurn();
		}
		else
		{
			EndEffect();
		}
	}
}
