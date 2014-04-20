using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or 
 * more damage):When this unit attacks a vanguard, this unit gets 
 * [Power]+5000 until end of that battle.
 * 
 * [AUTO]:[Counter Blast (2)] When this unit is placed on (VC), you
 * may pay the cost. If you do, search from your deck for up to one grade 
 * 2 or less «Gold Paladin», call it to (RC), and shuffle your deck.
 */

public class GreatSilverWolfGarmore : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && GetDefensor().IsVanguard()
			   && LimitBreak(4))
			{
				IncreasePowerByBattle(OwnerCard, 5000);
			}
		}
		else if(cs == CardState.Ride)
		{
			if(CB (2)
			   && GetDeck().Size () > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active ()
	{
		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SetBool(1);
				GetDeck ().ViewDeck(1,
				delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Gold Paladin");
				});
			});
		});

		ResolveDeckOpening(1,
		delegate {
			CallFromDeck (_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		CallFromDeckUpdate(delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
