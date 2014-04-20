using UnityEngine;
using System.Collections;

public class EarnestStarvaderSelenium : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner(OwnerCard.clan);
		}
		else if(cs == CardState.EnemyIsLocked)
		{
			if(RC()
			   && VanguardIs("Link Joker"))
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

	public override void Active ()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			ShowAndDelay();
		}
		else 
		{
			Forerunner_Active();
		}
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
}
