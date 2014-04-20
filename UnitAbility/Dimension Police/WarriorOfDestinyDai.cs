using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When another «Dimension Police» rides this unit, you may 
 * call this card to (RC).
 * 
 * [ACT](RC):[Counter Blast (1) & Put this unit into your soul] Look 
 * at up to five cards from the top of your deck, search for up to 
 * one grade 3 or greater «Dimension Police» from among them, reveal
 * it to your opponent, put it into your hand, and shuffle your deck.
 */

public class WarriorOfDestinyDai : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Dimension Police"))
			{
				SetBool(1);
				Forerunner("Dimension Police");
			}
		}
	}

	public override int Act ()
	{
		if(RC ()
		   && CB(1)
		   && GetDeck ().Size() > 0)
		{
			return 1;
		}

		return 0;
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
				GetDeck ().ViewDeck(1, SearchMode.TOP_CARD, min(5, GetDeck().Size()),
				delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Dimension Police") && c._CardInfo.grade == 3;
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
