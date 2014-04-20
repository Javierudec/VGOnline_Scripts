using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is placed on (RC), choose another of your 
 * «Narukami», and that unit gets [Power]+2000 until end of turn.
 */

public class DemonicDragonMageMajila : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Call)
        {
            if (NumUnits(delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Narukami"); }, true) > 0)
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
            SelectUnit("Choose another of your \"Narukami\"", 1, true,
            delegate
            {
                IncreasePowerByTurn(Unit, 2000);
            },
            delegate
            {
                return Unit != OwnerCard && Unit.BelongsToClan("Narukami");
            },
            delegate
            {

            });
        });
    }
}
