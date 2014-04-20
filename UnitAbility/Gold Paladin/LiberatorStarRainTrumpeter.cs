using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LiberatorStarRainTrumpeter : UnitObject {
	bool bCallPerformActionFunction = false;
	Card cardMoving = null;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(VanguardIs(OwnerCard.clan)
			   && (NumUnitsDrop(delegate(Card c) { return c.cardID == CardIdentifier.BLASTER_BLADE_LIBERATOR; }) + NumUnitsInSoul(delegate(Card c) { return c.cardID == CardIdentifier.BLASTER_BLADE_LIBERATOR; })) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			GetFieldWatcher().Reset();
			GetFieldWatcher().AddCardList(GetSoulZone());
			GetFieldWatcher().AddCardList(GetDropZone());

			GetFieldWatcher().Filter(delegate(Card c) {
				return c.cardID == CardIdentifier.BLASTER_BLADE_LIBERATOR;
			});

			GetFieldWatcher().SetActionToPerform(delegate(Card c) {
				cardMoving = c;

				if(c._Coord == CardCoord.SOUL)
				{
					FromSoulToDeck(c);
					bCallPerformActionFunction = true;
				}
				else if(c._Coord == CardCoord.DROP)
				{
					List<CardIdentifier> list = new List<CardIdentifier>();
					FromDropToDeck(list);
				}

				GetFieldWatcher().RemoveFromList(c);
				GetFieldWatcher().Close();
			});

			GetFieldWatcher().Open();
		});

		FromDropToDeckUpdate(delegate {
			bCallPerformActionFunction = true;
		});

		CallFromDeckUpdate(delegate {
			EndEffect();
		});

		if(bCallPerformActionFunction && (cardMoving != null && !cardMoving.AnimationOngoing()))
		{
			bCallPerformActionFunction = false;
			PerformNextAction();
		}
	}

	void PerformNextAction()
	{
		ShuffleDeck();
		if(OpenRC())
		{
			GetFieldWatcher().Reset();
			GetFieldWatcher().AddCardList(GetDeck().GetFirstCards(1));

			GetFieldWatcher().SetOnCloseEvent(delegate {
				List<Card> toBottomList = GetDeck().GetFirstCards(1);
				foreach(Card c in toBottomList)
				{
					GetDeck().RemoveFromDeck(c);
					GetDeck().AddToBottom(c);
					EndEffect();
				}
			});

			GetFieldWatcher().SetActionToPerform(delegate(Card c) {
				if(c.BelongsToClan("Gold Paladin"))
				{
					List<CardIdentifier> tmpList = new List<CardIdentifier>();
					tmpList.Add(c.cardID);
					GetFieldWatcher().Close();
					CallFromDeck(tmpList);
				}
			});
			GetFieldWatcher().Open();
		}
		else
		{
			EndEffect();
		}
	}
}
