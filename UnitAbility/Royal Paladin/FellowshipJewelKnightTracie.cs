using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit attacks, if the number of other rear-guards you 
 * have with "Jewel Knight" in its card name is three or more, this unit gets 
 * [Power]+3000 until end of that battle.
 */

public class FellowshipJewelKnightTracie : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Attacking)
        {
            if (RC() && NumUnits(delegate(Card c) { return c != OwnerCard && c.name.Contains("Jewel Knight"); }) >= 3)
            {
                IncreasePowerByBattle(OwnerCard, 3000);
            }
        }
    }
}
