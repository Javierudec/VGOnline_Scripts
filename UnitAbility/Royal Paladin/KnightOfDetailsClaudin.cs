using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):When this unit attacks, if you have a «Royal Paladin» 
 * vanguard or rear-guard with Limit Break 4, this unit gets [Power]+3000 until 
 * end of that battle.
 */

public class KnightOfDetailsClaudin : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Attacking)
        {
            if (NumUnits(delegate(Card c) { return c.bHasLimitBreak4 && c.BelongsToClan("Royal Paladin"); }, true) > 0)
            {
                IncreasePowerByBattle(OwnerCard, 3000);
            }
        }
    }
}
