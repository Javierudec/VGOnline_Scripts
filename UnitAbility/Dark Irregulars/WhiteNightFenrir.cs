using UnityEngine;
using System.Collections;

public class WhiteNightFenrir : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Link Joker");
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && GetDefensor().IsVanguard()
			   && GetAttacker() == tmp
			   && tmp.BelongsToClan("Link Joker")
			   && tmp.bHasLimitBreak4)
			{
				DisplayConfirmationWindow();
			}
		}
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
			MoveToSoul(OwnerCard);
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
}
