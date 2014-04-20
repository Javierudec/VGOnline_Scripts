using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is placed on (RC) from your deck, if you have a 
 * «Gold Paladin» vanguard, choose a card in your damage zone, turn it face 
 * up, and Soul Charge (1).
 */

public class KnightOfFarArrowsSaphir : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.CallFromDeck)
        {
            if (VanguardIs("Gold Paladin")
                && Game.field.GetNumberOfDamageCardsFacedown() > 0
                && GetDeck().Size() > 0)
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
