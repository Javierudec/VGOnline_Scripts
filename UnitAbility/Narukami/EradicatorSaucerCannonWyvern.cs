using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (1)] When this unit is placed on a (VC) or (RC), if you 
 * have a «Narukami» vanguard, you may pay the cost. If you do, choose one 
 * of your opponent's rear-guards in the front row, retire it, and your opponent 
 * draws a card.
 */

public class EradicatorSaucerCannonWyvern : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Ride || cs == CardState.Call)
        {
            if (CB(1)
               && VanguardIs("Narukami")
               && NumEnemyUnits(delegate(Card c) { return IsFrontRow(c); }) > 0)
            {
                DisplayConfirmationWindow();
            }
        }
    }

    public override void Active()
    {
        ShowAndDelay();
    }

    public override void Update()
    {
        DelayUpdate(
        delegate
        {
            SelectEnemyUnit("Choose one of your opponent's rear-guards in the front row.", 1, true,
            delegate
            {
                RetireEnemyUnit(EnemyUnit);
            },
            delegate
            {
                return IsFrontRow(EnemyUnit);
            },
            delegate
            {
                OpponentDrawCard();
                EndEffect();
            });
        });
    }
}
