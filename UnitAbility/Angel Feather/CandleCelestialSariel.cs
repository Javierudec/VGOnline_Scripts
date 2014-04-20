using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (1)] When this unit is placed on (RC), 
 * if you have an «Angel Feather» vanguard, you may pay the cost. 
 * If you do, search your deck for up to one «Angel Feather», put 
 * it into your damage zone, and shuffle your deck. If you put a 
 * card into the damage zone this way, choose a face up card from 
 * your damage zone, and put it into your drop zone.
 */

public class CandleCelestialSariel : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(CB (1)
			   && VanguardIs("Angel Feather")
			   && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active ()
	{
		ShowAndDelay();
	}

	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SetBool(1);
				GetDeck ().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Angel Feather");
				});
			});
		});

		ResolveDeckOpening(1,
		delegate {
			FromDeckToDamage(GetDeck().SearchForID(_AuxIdVector[0]), true);
			ShuffleDeck();

			SelectInDamage(1, true,
			delegate {
				FromDamageToDrop(_SID_Card);
			},
			delegate(Card c) {
				return c.IsFaceup();
			});
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
