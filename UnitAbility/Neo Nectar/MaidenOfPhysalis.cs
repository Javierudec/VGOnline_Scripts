using UnityEngine;
using System.Collections;

public class MaidenOfPhysalis : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Neo Nectar");
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && GetDefensor().IsVanguard()
			   && GetAttacker() == tmp
			   && tmp.BelongsToClan("Neo Nectar")
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

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			int n = min(5, GetDeck().Size());
			MoveToSoul(OwnerCard);
			SetBool(2);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD, n, delegate(Game2DCard c) {
				return c._CardInfo.BelongsToClan("Neo Nectar") && c._CardInfo.grade == 1;
			});
		});

		ResolveDeckOpening(2, 
		delegate {
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		CallFromDeckUpdate(delegate {
			RestUnit(CallFromDeckList[0]);
			EndEffect();
			ShuffleDeck();
		});
	}
}
