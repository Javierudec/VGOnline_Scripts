using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, 
 * you may call this unit to (RC))
 * 
 * [AUTO](RC):[Put this unit into your soul] When an attack hits a vanguard
 * during the battle that this unit boosted a «Angel Feather» that has Limit
 * Break 4, you may pay the cost. If you do, draw a card.
 */

public class CureDropAngel : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Angel Feather");
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;

			if(RC()
			   && GetDefensor().IsVanguard()
			   && GetAttacker() == tmp
			   && tmp.BelongsToClan("Angel Feather")
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

		DelayUpdate (delegate {
			MoveToSoul(OwnerCard);
			DrawCard(1);
		});

		DrawCardUpdate(delegate {
			EndEffect();
		});
	}
}
