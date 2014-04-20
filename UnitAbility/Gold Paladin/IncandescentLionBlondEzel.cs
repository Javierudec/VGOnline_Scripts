using UnityEngine;
using System.Collections;

/*
 * [ACT](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (2)] Look at the top card of your deck, search for 
 * up to one «Gold Paladin» from among them, call it to an open (RC), put the 
 * rest on the bottom of your deck, and increase this unit's [Power] by the 
 * original [Power] of the unit called with this effect until end of turn.
 * 
 * [CONT](VC):During your turn, this unit gets [Power]+1000 for each of your 
 * «Gold Paladin» rear-guards.
 */

public class IncandescentLionBlondEzel : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsPlayerTurn())
		{
			AddContPower(1000 * NumUnits(delegate(Card c) { return c.BelongsToClan("Gold Paladin"); }));
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB(2)
		   && GetDeck().Size() > 0
		   && OpenRC())
		{
			return 1;
		}

		return 0;
	}

	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SetBool(1);
				GetDeck().ViewDeck(1, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, 1,
				delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Gold Paladin");
				});
			});
		});

		ResolveDeckOpening(1,
		delegate {
			OnlyOpenRC(true);
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
		});

		CallFromDeckUpdate(delegate {
			OnlyOpenRC(false);
			IncreasePowerByTurn(OwnerCard, CallFromDeckList[0].GetPower());
			EndEffect();
		});
	}
}
