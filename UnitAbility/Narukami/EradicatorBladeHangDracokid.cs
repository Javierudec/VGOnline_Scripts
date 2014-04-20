using UnityEngine;
using System.Collections;

public class EradicatorBladeHangDracokid : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner(OwnerCard.clan);
		}
		else if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(RC ()
			   && ownerEffect.retireUnitOwner.name.Contains("Eradicator")
			   && GetVanguard().name.Contains("Vowing"))
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Active()
	{
		if(GetBool (1))
		{
			UnsetBool(1);
			ShowAndDelay();
		}
		else
		{
			Forerunner_Active();
		}
	}

	public override void Update()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			IncreasePowerAndCriticalByTurn(GetVanguard(), 3000, 1);
			EndEffect();
		});
	}
}
