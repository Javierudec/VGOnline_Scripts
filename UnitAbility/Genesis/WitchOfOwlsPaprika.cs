using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):When this unit attacks, if you have a «Genesis» vanguard 
 * or rear-guard with Limit Break 4, this unit gets [Power]+3000 until end of 
 * that battle.
 */

public class WitchOfOwlsPaprika : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Attacking)
        {
            if (NumUnits(delegate(Card c) { return c.BelongsToClan("Genesis") && c.bHasLimitBreak4; }) > 0)
            {
                IncreasePowerByBattle(OwnerCard, 3000);
            }
        }
    }
}
