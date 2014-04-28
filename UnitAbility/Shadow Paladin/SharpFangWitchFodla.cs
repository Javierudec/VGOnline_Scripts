using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SharpFangWitchFodla : UnitObject {
	int num_calls = 0;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB(1)
			   && VanguardIs("Shadow Paladin")
			   && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				num_calls = 2;

				GetFieldWatcher().Reset();
				GetFieldWatcher().AddCardList(GetDeck().getCardList());

				GetFieldWatcher().Filter(delegate(Card c) {
					return c.grade == 0 && c.BelongsToClan("Shadow Paladin");
				});

				GetFieldWatcher().SetActionToPerform(delegate(Card c) {
					List<CardIdentifier> tmpList = new List<CardIdentifier>();

					tmpList.Add(c.cardID);

					CallFromDeck(tmpList);
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
