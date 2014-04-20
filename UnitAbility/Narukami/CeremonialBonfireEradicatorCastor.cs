using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Choose a card from your hand, and discard it] When this unit is 
 * placed on (RC), if you have a «Narukami» vanguard, and if the number of 
 * rear-guards your opponent has is two or less, you may pay the cost. If you 
 * do, draw a card.
 */

public class CeremonialBonfireEradicatorCastor : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Call)
        {
            if(VanguardIs("Narukami")
               && NumEnemyUnits(delegate(Card c) { return true; }) <= 2
               && HandSize() > 0)
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
            SelectInHand(1, false,
            delegate
            {
                DiscardSelectedCard();
            },
            delegate
            {
                return true;
            },
            delegate
            {
                DrawCard(1);
            }, "Choose a card from your hand.");
        });

        DrawCardUpdate(
        delegate
        {
            EndEffect();
        });
    }
}
