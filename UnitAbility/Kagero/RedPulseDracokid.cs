using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit,
 * you may call this unit to (RC))
 * 
 * [ACT](RC):[Counter Blast (1) & Put this unit into your soul] Look at
 * up to five cards from the top of your deck, search for up to one grade 
 * 3 or greater «Kagerō» from among them, reveal it to your opponent, put 
 * it into your hand, and shuffle your deck.
 */

public class RedPulseDracokid : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs ("Kagero"))
			{
				SetBool(1);
				Forerunner("Kagero");
			}
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override int Act ()
	{
		if(RC ()
		   && CB (1)
		   && GetDeck().Size() > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate (delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				SetBool(2);
				GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min (5, GetDeck ().Size()), delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Kagero") && c._CardInfo.grade >= 3;
				});
			});
		});

		ResolveDeckOpening(2,
		delegate {
			FromDeckToHand(_AuxIdVector[0]);
			EndEffect();
			ShuffleDeck();
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
