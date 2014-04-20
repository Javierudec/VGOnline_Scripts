using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (1) - Cards with "Liberator" in its card name]
 * When this unit's attack hits a vanguard, if you have a «Gold Paladin» 
 * vanguard, you may pay the cost. If you do, look at the top card of your 
 * deck, search for up to one «Gold Paladin» from among them, call it to an 
 * open (RC), and put the rest on the bottom of your deck.
 */

public class LiberatorOfTheFluteEscrad : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.AttackHits)
        {
            if (GetDefensor().IsVanguard() && VanguardIs("Gold Paladin") && CB(1, delegate(Card c) { return c.name.Contains("Liberator"); }) && OpenRC() && GetDeck().Size() > 0)
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
                SetBool(1);
                GetDeck().ViewDeck(1, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, 1, delegate(Game2DCard c)
                {
                    return c._CardInfo.BelongsToClan("Gold Paladin");
                });
            },
            delegate(Card c)
            {
                return c.name.Contains("Liberator");
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
        });

        CallFromDeckUpdate(
        delegate
        {
            EndEffect();
        });
    }
}
