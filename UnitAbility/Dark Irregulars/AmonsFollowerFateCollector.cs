using UnityEngine;
using System.Collections;

public class AmonsFollowerFateCollector : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Dark Irregulars");
		}
		else if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC()
			   && tmp.BelongsToClan("Dark Irregulars")
			   && NumUnits (delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) >= 6)
			{
				SetBool(2);
			}
		}
		else if(cs == CardState.EndBattle_NotMe)
		{
			if(GetBool (2)
			   && GetDeck().Size() > 0)
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}

			UnsetBool(2);
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
