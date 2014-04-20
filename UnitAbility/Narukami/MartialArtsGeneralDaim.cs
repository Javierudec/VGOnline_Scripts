using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC):At the beginning of your main phase, Soul Charge (1), and this 
 * unit gets [Power]+2000 until end of turn.
 * 
 * [ACT](VC):[Soul Blast (8) & Counter Blast (5)] Choose one of your 
 * opponent's rear-guards for each of your "Narukami" rear-guards, and retire 
 * them.
 */

public class MartialArtsGeneralDaim : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.BeginMain)
        {
            if (VC() && GetDeck().Size() > 0)
            {
                SetBool(1);
                StartEffect();
                ShowAndDelay();
            }
        }
    }

    public override int Act()
    {
        if (VC() && CanSoulBlast(8) && CB(5))
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
        DelayUpdate(delegate
        {
            if (GetBool(1))
            {
                UnsetBool(1);
                SoulCharge(1);
            }
            else
            {
                SoulBlast(8);
            }
        });

        SoulBlastUpdate(delegate
        {
            CounterBlast(5, delegate
            {
                int narukamiRearguards = NumUnits(delegate(Card c) { return c.BelongsToClan("Narukami"); });
                int enemyRearguards = NumEnemyUnits(delegate(Card c) { return true; });
                int num = min(narukamiRearguards, enemyRearguards);
                if (num > 0)
                {
                    SelectEnemyUnit("Choose " + num + " of your opponent's rear-guards.", num, true,
                    delegate
                    {
                        RetireEnemyUnit(EnemyUnit);
                    },
                    delegate
                    {
                        return true;
                    },
                    delegate
                    {

                    });
                }
                else
                {
                    EndEffect();
                }
            });
        });

        SoulChargeUpdate(delegate
        {
            IncreasePowerByTurn(OwnerCard, 2000);
            EndEffect();
        });
    }
}
