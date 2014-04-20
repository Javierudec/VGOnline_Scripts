using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (1) - «Genesis»] When this unit attacks, if you 
 * have a «Genesis» vanguard, you may pay the cost. If you do, this unit 
 * gets [Power]+4000 until end of that battle.
 */

public class CleverJake : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Attacking)
        {
            if(CB(1, delegate(Card c) { return c.BelongsToClan("Genesis"); })
               && VanguardIs("Genesis"))
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
                IncreasePowerByBattle(OwnerCard, 4000);
                EndEffect();
            },
            delegate(Card c)
            {
                return c.BelongsToClan("Genesis");
            });
        });
    }
}
