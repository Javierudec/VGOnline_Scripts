using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Soul Blast (1)] When this unit boosts a unit named "Liberator
 * of the Round Table, Alfred", you may pay the cost. If you do, the boosted 
 * unit gets [Power]+5000 until end of that battle.
 */

public class LiberatorFlareManeStallion : UnitObject {
    public override void Auto(CardState cs, Card effetOwner)
    {
        if (cs == CardState.Boost)
        {
            Card tmp = OwnerCard.boostedUnit;
            if(RC()
               && CanSoulBlast(1)
               && tmp.cardID == CardIdentifier.LIBERATOR_OF_THE_ROUND_TABLE__ALFRED)
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
