using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit,
 * you may call this unit to (RC))
 * 
 * [AUTO]:[Counter Blast (1)] When this unit is put into the drop 
 * zone from (RC), if you have a «Tachikaze» vanguard, you may pay 
 * the cost. If you do, search your deck for up to one card named 
 * "Ancient Dragon, Tyrannolegend", call it to (RC), and shuffle your deck.
 */

public class AncientDragonBabyrex : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Tachikaze");
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(CB (1)
			   && VanguardIs("Tachikaze"))
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
			CounterBlast(1,
			delegate {
				SetBool(2);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.cardID == CardIdentifier.ANCIENT_DRAGON__TYRANNOLEGEND;
				});
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

		CallFromDeckUpdate (delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
