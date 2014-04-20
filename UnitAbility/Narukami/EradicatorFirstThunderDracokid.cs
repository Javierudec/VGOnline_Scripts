using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit,
 * you may call this unit to (RC))
 * 
 * [AUTO](RC):[Put this unit into your soul] When an opponent's rear-guard 
 * is put into the drop zone by your effects from cards, if you have a grade
 * 3 or greater vanguard with "Eradicator" in its card name, you may pay the 
 * cost. If you do, look at up to ten cards from the top of your deck, search 
 * for up to one card named "Eradicator, Sweep Command Dragon" from among them,
 * ride it, and shuffle your deck.
 */

public class EradicatorFirstThunderDracokid : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Narukami");
		}
		else if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(RC() 
			   && GetVanguard().name.Contains("Eradicator")
			   && GetVanguard().grade >= 3
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
			MoveToSoul(OwnerCard);
			SetBool(2);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min (10, GetDeck().Size()), delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.ERADICATOR__SWEEP_COMMAND_DRAGON;
			});
		});

		ResolveDeckOpening(2, 
		delegate {
			RideFromDeck(GetDeck().SearchForID(_AuxIdVector[0]));
			EndEffect();
			ShuffleDeck();
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
