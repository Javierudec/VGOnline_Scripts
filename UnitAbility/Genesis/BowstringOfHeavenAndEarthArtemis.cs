using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):If you have a card named "Aiming for the Stars, Artemis" in 
 * your soul, this unit gets [Power]+1000.
 * 
 * [AUTO]: When a grade 2 «Genesis» not named "Twilight Hunter, Artemis" 
 * rides this unit, if you have a card named "Aiming for the Stars, Artemis" in 
 * your soul, look at up to seven cards from the top of your deck, search for up 
 * to one card named "Twilight Hunter, Artemis" from among them, ride it, and 
 * shuffle your deck.
 */

public class BowstringOfHeavenAndEarthArtemis : UnitObject {
    public override void Cont()
    {
        int power = 0;
        if (VC() && IsInSoul(CardIdentifier.AIMING_FOR_THE_STARS__ARTEMIS))
        {
            power += 1000;
        }
        SetPower(power);
    }

    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.RideAboveIt)
        {
            if(GetVanguard().grade == 2 
               && GetVanguard().BelongsToClan("Genesis")
               && GetVanguard().cardID != CardIdentifier.TWILIGHT_HUNTER__ARTEMIS
               && IsInSoul(CardIdentifier.AIMING_FOR_THE_STARS__ARTEMIS)
               && GetDeck().Size() > 0)
            {
                StartEffect();
                ShowAndDelay();
            }
        }
    }

    public override void Update()
    {
        DelayUpdate(
        delegate
        {
            int n = min(7, GetDeck().Size());
            SetBool(1);
            GetDeck().ViewDeck(1, SearchMode.TOP_CARD, n,
            delegate(Game2DCard c)
            {
                return c._CardInfo.cardID == CardIdentifier.TWILIGHT_HUNTER__ARTEMIS;
            });
        });

        ResolveDeckOpening(1,
        delegate
        {
            RideFromDeck(GetDeck().SearchForID(_AuxIdVector[0]));
            EndEffect();
            ShuffleDeck();
        },
        delegate
        {
            EndEffect();
            ShuffleDeck();
        });
    }
}
