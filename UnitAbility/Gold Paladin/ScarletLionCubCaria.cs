using UnityEngine;
using System.Collections;

public class ScarletLionCubCaria : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Gold Paladin");
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC()
			   && GetDefensor().IsVanguard()
			   && GetAttacker() == tmp
			   && tmp.name.Contains("Ezel")
			   && GetDeck().Size() > 0
			   && OpenRC())
			{
				SetBool(1);
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

	public override void Update()
	{
		Forerunner_Update();

		DelayUpdate (delegate {
			MoveToSoul(OwnerCard);
			SetBool(2);
			int n = min(NumOpenRC(), min(2, GetDeck().Size()));
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, n, delegate(Game2DCard c) {
				return c._CardInfo.BelongsToClan("Gold Paladin");
			});
		});

		ResolveDeckOpening(2, 
		delegate {
			OnlyOpenRC(true);
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
		});

		CallFromDeckUpdate(delegate {
			OnlyOpenRC(false);
			for(int i = 0; i < CallFromDeckList.Count; i++)
			{
				RestUnit(CallFromDeckList[i]);
			}
			EndEffect();
		});
	}
}
