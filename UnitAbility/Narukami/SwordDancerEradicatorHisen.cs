using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Soul Blast (1)] When this unit boosts a unit named "Eradicator, 
 * Dragonic Descendant", you may pay the cost. If you do, the boosted unit 
 * gets [Power]+5000 until end of that battle.
 */

public class SwordDancerEradicatorHisen : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Boost)
        {
            Card tmp = OwnerCard.boostedUnit;
            if(RC()
               && CanSoulBlast(1)
               && tmp.cardID == CardIdentifier.ERADICATOR__DRAGONIC_DESCENDANT)
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

        SoulBlastUpdate(
        delegate
        {
            IncreasePowerByBattle(OwnerCard.boostedUnit, 5000);
            EndEffect();
        });
    }
}
