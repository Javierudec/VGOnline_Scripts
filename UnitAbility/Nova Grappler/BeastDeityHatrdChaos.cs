using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC): When this unit attacks, if you have a vanguard with "Beast +
 * Deity" in its card name, this unit gets [Power]+3000 until end of the battle.
 */

public class BeastDeityHatrdChaos : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Attacking)
        {
            if (RC() && GetVanguard().name.Contains("Beast Deity"))
            {
                IncreasePowerByBattle(OwnerCard, 3000);
            }
        }
    }
}
