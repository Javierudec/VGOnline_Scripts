using UnityEngine;
using System.Collections;

public class WerfuchsHexer : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Dark Irregulars");
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC()
			   && GetDefensor ().IsVanguard()
			   && GetAttacker() == tmp
			   && tmp.BelongsToClan("Dark Irregulars")
			   && tmp.bHasLimitBreak4
			   && GetDeck().Size() > 0)
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
			ShowAndDelay();
			UnsetBool(1);
		}
		else
		{
			Forerunner_Update();
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
