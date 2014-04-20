using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, you may 
 * call this unit to (RC))
 * 
 * [ACT](RC):[Put this unit into your soul] Choose up to two of your other rear-
 * guards with "Jewel Knight" in its card name, and those units get 
 * [Power]+3000 until end of turn.
 */

public class DreamingJewelKnightTiffany : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.RideAboveIt)
        {
            if (VanguardIs("Royal Paladin"))
            {
                SetBool(1);
                Forerunner("Royal Paladin");
            }
        }
    }

    public override int Act()
    {
        if (RC() && NumUnits(delegate(Card c) { return c != OwnerCard && c.name.Contains("Jewel Knight"); }) > 0)
        {
            return 1;
        }
        
        return 0;
    }

    public override bool Cancel()
    {
        UnsetBool(1);
        return true;
    }

    public override void Active()
    {
        if (GetBool(1))
        {
            UnsetBool(1);
            Forerunner_Active();
        }
        else
        {
            StartEffect();
            ShowAndDelay();
        }
    }

    public override void Update()
    {
        Forerunner_Update();

        DelayUpdate(
        delegate
        {
            MoveToSoul(OwnerCard);
            int num = min(2, NumUnits(delegate(Card c) { return c.name.Contains("Jewel Knight"); }));
            SelectUnit("Choose up to " + num + " of your rear-guards with \"Jewel Knight\" in its card name.", num, true,
            delegate
            {
                IncreasePowerByTurn(Unit, 3000);
            },
            delegate
            {
                return Unit.name.Contains("Jewel Knight");
            },
            delegate
            {

            });
        });
    }

    public override void Pointer()
    {
        SelectUnit_Pointer(true);
    }
}
