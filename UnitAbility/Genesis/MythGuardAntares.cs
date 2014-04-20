using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When your grade 3 «Royal Paladin» is placed on (VC), this unit 
 * gets [Power]+10000 until the end of turn.
 */

public class MythGuardAntares : UnitObject {
    public override void Auto(CardState cs, Card ownerEffect)
    {
        if (cs == CardState.Ride_NotMe)
        {
            if (RC() && VanguardIs(OwnerCard.clan) && GetVanguard().grade == 3)
            {
                IncreasePowerByTurn(OwnerCard, 10000);
            }
        }
    }
}
