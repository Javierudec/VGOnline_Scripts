using UnityEngine;
using System.Collections;

public class JudgebauRevenger : UnitObject {
	bool bActiveForerunner = false;
	int num_calls = 2;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			bActiveForerunner = true;
			Forerunner(OwnerCard.clan);
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(ownerEffect == OwnerCard.boostedUnit
			   && c.name.Contains("Phantom")
			   && CB(1))
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override bool Cancel ()
	{
		bActiveForerunner = false;

		return true;
	}

	public override void Active ()
	{
		if(bActiveForerunner)
		{
			bActiveForerunner = false;
			Forerunner_Active();
		}
		else
		{
			ShowAndDelay();
		}
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				num_calls = 2;
				GetFieldWatcher().Reset();
				GetFieldWatcher().AddCardList(GetDeck().getCardList());
				GetFieldWatcher().Filter(delegate(Card c) {
					return c.grade <= 1 && c.BelongsToClan("Shadow Paladin");
				});
				GetFieldWatcher().SetActionToPerform(delegate(Card c) {
					CallFromDeck(c);
					GetFieldWatcher().RemoveFromList(c);
					GetFieldWatcher().Close();
					num_calls--;
				});
				GetFieldWatcher().SetOnCloseEvent(delegate {
					EndEffect();
				});
				GetFieldWatcher().Open();
			});
		});

		CallFromDeckUpdate(delegate {
			RestUnit(CallFromDeckList[0]);

			if(num_calls > 0)
			{
				GetFieldWatcher().Open();
			}
			else
			{
				EndEffect();
			}
		});
	}
}
