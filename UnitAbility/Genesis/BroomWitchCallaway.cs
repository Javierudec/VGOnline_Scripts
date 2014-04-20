using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (2)] When this unit's attack hits, if you have a 
 * «Genesis» vanguard, you can pay the cost. If you do, draw a card.
 */

public class BroomWitchCallaway : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.AttackHits)
        {
            if (VanguardIs("Genesis") && CB(2) && GetDeck().Size() > 0)
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
            CounterBlast(2,
            delegate
            {
                DrawCard(1);
            });
        });

        DrawCardUpdate(
        delegate
        {
            EndEffect();
        });
    }
}
