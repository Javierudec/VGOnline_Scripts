using UnityEngine;
using System.Collections;

/*
 * [CONT](VC/RC): During your turn, if you have a card named "Myth 
 * Guard, Orion" in your soul, this unit gets [Power] +3000.
 */

public class MythGuardSirius : UnitObject {
    public override void Cont()
    {
        int power = 0;
        if (IsPlayerTurn() && IsInSoul(CardIdentifier.MICE_GUARD__ORION))
        {
            power += 3000;
        }
        SetPower(power);
    }
}
