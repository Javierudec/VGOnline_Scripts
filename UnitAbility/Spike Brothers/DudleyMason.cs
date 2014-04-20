using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (1) & Choose one «Spike Brothers» from 
 * your hand, and put it into your soul] When this unit's attack hits a vanguard, if 
 * you have a «Spike Brothers» vanguard, you may pay the cost. If you do, 
 * search your deck for up to one «Spike Brothers», call it to a open (RC), and 
 * shuffle your deck.
 */

public class DudleyMason : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.AttackHits)
        {
            if (CB(1) 
                && HandSize(delegate(Card c) { return c.BelongsToClan("Spike Brothers"); }) > 0
                && VanguardIs("Spike Brothers")
                && OpenRC()
                && GetDeck().Size() > 0)
            {
                DisplayConfirmationWindow();
            }
        }
    }

    public override void Active()
    {
        ShowAndDelay();
    }

    public override void Update()
    {
        DelayUpdate(
        delegate
        {
            CounterBlast(1,
            delegate
            {
                SelectInHand(1, false,
                delegate
                {
                    FromHandToSoul(_SIH_Card, GetHand().GetCurrentCard());
                },
                delegate
                {
                    return _SIH_Card.BelongsToClan("Spike Brothers");
                },
                delegate
                {

                }, "Choose one \"Spike Brothers\" from your hand.");
            });
        });

        FromHandToSoulUpdate(
        delegate
        {
            SetBool(1);
            GetDeck().ViewDeck(1,
            delegate(Game2DCard c)
            {
                return c._CardInfo.BelongsToClan("Spike Brothers");
            });
        });

        ResolveDeckOpening(1,
        delegate
        {
            OnlyOpenRC(true);
            CallFromDeck(_AuxIdVector);
        },
        delegate
        {
            EndEffect();
            ShuffleDeck();
        });

        CallFromDeckUpdate(
        delegate
        {
			OnlyOpenRC(false);
            EndEffect();
            ShuffleDeck();
        });
    }
}
