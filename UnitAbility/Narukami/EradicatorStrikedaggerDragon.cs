using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, you may 
 * call this unit to (RC))
 * 
 * [ACT](RC):[Put this unit into soul & Choose a unit named "Sword Dance 
 * Eradicator, Hisen" on your (RC), and put it into soul] If you have a 
 * unit named "Supreme Army Eradicator, Zuitan" on your (VC), search your 
 * deck for up to one card named "Eradicator, Dragonic Descendant", ride it,
 * and shuffle your deck.
 */

public class EradicatorStrikedaggerDragon : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.RideAboveIt)
        {
            if (VanguardIs("Narukami"))
            {
                SetBool(1);
                Forerunner("Narukami");
            }
        }
    }

    public override int Act()
    {
        if(RC()
           && NumUnits(delegate(Card c) { return c.cardID == CardIdentifier.SWORD_DANCE_ERADICATOR__HISEN; }) > 0)
        {
            return 1;
        }

        return 0;
    }

    public override bool Cancel()
    {
        UnsetBool(1);
        return true;
    }

    public override void Active()
    {
        if (GetBool(1))
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

    public override void Update()
    {
        Forerunner_Update();

        DelayUpdate(
        delegate
        {
            if (GetVanguard().cardID == CardIdentifier.SUPREME_ARMY_ERADICATOR__ZUITAN && GetDeck().Size() > 0)
            {
                SetBool(2);
                GetDeck().ViewDeck(1,
                delegate(Game2DCard c)
                {
                    return c._CardInfo.cardID == CardIdentifier.ERADICATOR__DRAGONIC_DESCENDANT;
                });
            }
            else
            {
                EndEffect();
            }
        });

        ResolveDeckOpening(2,
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
