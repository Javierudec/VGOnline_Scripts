﻿using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, you may 
 * call this unit to (RC))
 * 
 * [AUTO](RC):[Put this unit into your soul] When an attack hits a vanguard 
 * during the battle that this unit boosted a «Gold Paladin» that has Limit Break 
 * 4, you may pay the cost. If you do, draw a card.
 */

public class HolySquireEnide : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.RideAboveIt)
        {
            Forerunner("Gold Paladin");
        }
        else if (cs == CardState.AttackHits_NotMe)
        {
            Card tmp = OwnerCard.boostedUnit;
            if(RC()
               && GetAttacker() == tmp
               && GetDefensor().IsVanguard()
               && tmp.BelongsToClan("Gold Paladin")
               && tmp.bHasLimitBreak4
               && GetDeck().Size() > 0)
            {
                SetBool(1);
                DisplayConfirmationWindow();
            }
        }
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
            MoveToSoul(OwnerCard);
            DrawCard(1);
        });

        DrawCardUpdate(
        delegate
        {
            EndEffect();
        });
    }
}
