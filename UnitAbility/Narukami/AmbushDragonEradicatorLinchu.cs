using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, you may 
 * call this unit to (RC))
 * 
 * [AUTO](RC):[Counter Blast (1) & Put this unit into your soul] When an attack 
 * hits a vanguard during the battle that this unit boosted a unit with "Eradicator" 
 * in its card name, you may pay the cost. If you do, choose one of your 
 * opponent's grade 1 or less rear-guards, and retire it.
 */

public class AmbushDragonEradicatorLinchu : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.RideAboveIt)
        {
            Forerunner("Narukami");
        }
        else if (cs == CardState.AttackHits_NotMe)
        {
            Card tmp = OwnerCard.boostedUnit;
            if(RC()
               && CB(1)
               && tmp != null
               && tmp.name.Contains("Eradicator")
               && GetAttacker() == tmp
               && GetDefensor().IsVanguard()
               && NumEnemyUnits(delegate(Card c) { return c.grade <= 1; }) > 0)
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
            CounterBlast(1,
            delegate
            {
                MoveToSoul(OwnerCard);
                SelectEnemyUnit("Choose one of your opponent's grade 1 or less rear-guards.", 1, true,
                delegate
                {
                    RetireEnemyUnit(EnemyUnit);
                },
                delegate
                {
                    return EnemyUnit.grade <= 1;
                },
                delegate
                {

                });
            });
        });
    }
}
