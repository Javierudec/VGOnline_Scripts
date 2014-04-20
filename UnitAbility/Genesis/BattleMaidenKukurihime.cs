using UnityEngine;
using System.Collections;

/*
 * [ACT](RC):[Put this unit into your soul] Choose up to one of your 
 * «Genesis», and that unit gets [Power] +3000 until end of turn.
 */

public class BattleMaidenKukurihime : UnitObject {
    public override int Act()
    {
        if (RC() && NumUnits(delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Genesis"); }, true) > 0)
        {
            return 1;
        }

        return 0;
    }

    public override void Active()
    {
        StartEffect();
        ShowAndDelay();
    }

    public override void Update()
    {
        DelayUpdate(
        delegate
        {
            MoveToSoul(OwnerCard);
            SelectUnit("Choose one of your \"Genesis\"", 1, true,
            delegate
            {
                IncreasePowerByTurn(OwnerCard, 3000);
            },
            delegate
            {
                return Unit.BelongsToClan("Genesis");
            },
            delegate
            {

            }, true);
        });
    }
}
