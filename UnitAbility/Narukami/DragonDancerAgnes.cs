using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Counter Blast (1)] When this unit boosts a «Narukami» with 
 * Limit Break 4, you may pay the cost. If you do, the boosted unit gets 
 * [Power]+3000 until end of that battle.
 */

public class DragonDancerAgnes : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Boost)
        {
            Card tmp = OwnerCard.boostedUnit;
            if(RC()
               && CB(1)
               && tmp.BelongsToClan("Narukami")
               && tmp.bHasLimitBreak4)
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
                IncreasePowerByBattle(OwnerCard.boostedUnit, 3000);
                EndEffect();
            });
        });
    }
}
