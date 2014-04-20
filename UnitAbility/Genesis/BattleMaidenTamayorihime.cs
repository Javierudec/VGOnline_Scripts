using UnityEngine;
using System.Collections;

public class BattleMaidenTamayorihime : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.RideAboveIt)
        {
            Forerunner("Genesis");
        }
        else if (cs == CardState.AttackHits_NotMe)
        {
            Card tmp = OwnerCard.boostedUnit;
            if(tmp != null
               && tmp.BelongsToClan("Genesis")
               && GetDefensor().IsVanguard()
               && GetDeck().Size() >= 3
               && CB(2)
               && RC()
               && (GetAttacker() == tmp))
            {
                SetBool(1);
                DisplayConfirmationWindow();
            }
        }
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
            ShowAndDelay();
        }
        else
        {
            Forerunner_Active();
        }
    }

    public override void Update()
    {
        Forerunner_Update();

        DelayUpdate(
        delegate
        {
            CounterBlast(2,
            delegate
            {
               SoulCharge(3); 
            });
        });

        SoulChargeUpdate(delegate
        {
            EndEffect();
        });
    }
}
