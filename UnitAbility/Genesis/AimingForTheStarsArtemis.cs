using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When a unit named "Bowstring of Heaven and Earth, Artemis" rides 
 * this unit, look at up to seven cards from the top of your deck, search for up 
 * to one card named "Twilight Hunter, Artemis" or "Battle Deity of the Night, 
 * Artemis" from among them, reveal it to your opponent, put it to your hand,
 * and shuffle your deck.
 * 
 * [AUTO]:When a «Genesis» other than a card named "Bowstring of Heaven 
 * and Earth, Artemis" rides this unit, you may call this card to (RC).
 */

public class AimingForTheStarsArtemis : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.RideAboveIt)
        {
            if (GetVanguard().cardID == CardIdentifier.BOWSTRING_OF_HEAVEN_AND_EARTH__ARTEMIS
                && GetDeck().Size() > 0)
            {
                StartEffect();
                ShowAndDelay();
            }
            else 
            {
                Forerunner("Genesis");
            }
        }
    }

    public override void Active()
    {
        Forerunner_Active();
    }

    public override void Update()
    {
        Forerunner_Update();

        DelayUpdate(
        delegate
        {
            SetBool(1);
            GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min(7, GetDeck().Size()),
            delegate(Game2DCard c)
            {
                return c._CardInfo.cardID == CardIdentifier.TWILIGHT_HUNTER__ARTEMIS
                    || c._CardInfo.cardID == CardIdentifier.BATTLE_DEITY_OF_THE_NIGHT__ARTEMIS;
            });
        });

        ResolveDeckOpening(1,
        delegate
        {
            FromDeckToHand(_AuxIdVector[0]);
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
