using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When an opponent's rear-guard is put into the drop zone by 
 * your effects from cards, if you have a vanguard with "Eradicator" in its card 
 * name, this unit gets [Power]+3000 until end of turn.
 */

public class DoubleGunEradicatorNakusho : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.EnemyCardSendToDropZone)
        {
            if(RC()
               && GetVanguard().name.Contains("Eradicator"))
            {
                IncreasePowerByTurn(OwnerCard, 3000);
            }
        }
    }
}
