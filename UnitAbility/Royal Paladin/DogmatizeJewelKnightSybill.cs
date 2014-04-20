using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (2)] When this unit is placed on (VC) or (RC), if you 
 * have a «Royal Paladin» vanguard, you may pay the cost. If you do, search 
 * your deck for up to one grade 1 or less unit with "Jewel Knight" in its card 
 * name, call it to (RC), and shuffle your deck.
 */

public class DogmatizeJewelKnightSybill : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Ride || cs == CardState.Call)
        {
            if (VanguardIs("Royal Paladin") && CB(2) && GetDeck().Size() > 0)
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
        DelayUpdate(delegate
        {
            CounterBlast(2, delegate
            {
                SetBool(1);
                GetDeck().ViewDeck(1, delegate(Game2DCard c)
                {
                    return c._CardInfo.name.Contains("Jewel Knight") && c._CardInfo.grade <= 1;
                });
            });
        });

        ResolveDeckOpening(1, 
        delegate
        {
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
            ShuffleDeck();
        });
    }
}
