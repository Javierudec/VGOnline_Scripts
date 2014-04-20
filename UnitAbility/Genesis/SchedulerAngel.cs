using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC): When this unit is boosted by a «Genesis», this unit gets 
 * Power +2000 until end of that battle.
 */

public class SchedulerAngel : UnitObject {
    public override void Auto(CardState cs, Card ownerEffect)
    {
        if (cs == CardState.IsBoosted)
        {
            Card tmp = OwnerCard.IsBoostedBy;
            if (tmp != null && tmp.BelongsToClan("Genesis"))
            {
                IncreasePowerByBattle(OwnerCard, 2000);
            }
        }
    }
}
