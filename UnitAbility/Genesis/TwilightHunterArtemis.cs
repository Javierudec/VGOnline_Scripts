using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):If you have a card named "Bowstring of Heaven and Earth, 
 * Artemis" in your soul, this unit gets [Power]+1000.
 * 
 * [AUTO](VC):When this unit's attack hits a vanguard, Soul Charge (2), and if 
 * you have "Bowstring of Heaven and Earth, Artemis" in your soul, Soul 
 * Charge (2).
 */

public class TwilightHunterArtemis : UnitObject {
    public override void Cont()
    {
        int power = 0;
        if (VC() && IsInSoul(CardIdentifier.BOWSTRING_OF_HEAVEN_AND_EARTH__ARTEMIS))
        {
            power += 1000;
        }
        SetPower(power);
    }

    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.AttackHits)
        {
            if (VC() && GetDefensor().IsVanguard() && GetDeck().Size() >= 2)
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
            if (IsInSoul(CardIdentifier.BOWSTRING_OF_HEAVEN_AND_EARTH__ARTEMIS) && GetDeck().Size() >= 4)
            {
                SoulCharge(4);
            }
            else
            {
                SoulCharge(2);
            }
        });

        SoulChargeUpdate(
        delegate
        {
            EndEffect();
        });
    }
}
