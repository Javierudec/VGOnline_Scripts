using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Soul Blast (1)] When this unit boosts a card named 
 * "Eradicator, Gauntlet Buster Dragon", you may pay the cost. If you do, the 
 * boosted unit gets [Power]+5000 until end of that battle.
 */

public class LightingFistEradicatorDui : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Boost)
        {
            Card tmp = OwnerCard.boostedUnit;
            if(RC()
               && CanSoulBlast(1)
               && tmp.cardID == CardIdentifier.ERADICATOR__GAUNTLET_BUSTER_DRAGON)
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
            SoulBlast(1);
        });

        SoulBlastUpdate(delegate
        {
            IncreasePowerByBattle(OwnerCard.boostedUnit, 5000);
            EndEffect();
        });
    }
}
