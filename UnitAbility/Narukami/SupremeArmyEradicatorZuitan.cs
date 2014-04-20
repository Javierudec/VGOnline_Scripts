using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):When this unit's attack hits a vanguard, if you have a 
 * vanguard with "Eradicator" in its card name, choose a card from your 
 * damage zone, turn it face up, and Soul Charge (1).
 */

public class SupremeArmyEradicatorZuitan : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.AttackHits)
        {
            if (GetDefensor().IsVanguard() && GetVanguard().name.Contains("Eradicator") && Game.field.GetNumberOfDamageCardsFacedown() > 0 && GetDeck().Size() > 0)
            {
                StartEffect();
                ShowAndDelay();
            }
        }
    }

    public override void Update()
    {
        DelayUpdate(
        delegate
        {
            Flipup(1,
            delegate
            {
                SoulCharge(1);
            });
        });

        SoulChargeUpdate(
        delegate
        {
            EndEffect();
        });
    }
}
