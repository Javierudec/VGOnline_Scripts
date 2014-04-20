using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Choose a card from your hand, and discard it] When this unit is 
 * placed on (RC), if the number of other rear-guards you have with "Jewel 
 * Knight" in its card name is three or more, you may pay the cost. If you do, 
 * draw a card.
 */

public class JewelKinghtPizmy : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Call)
        {
            if (NumUnits(delegate(Card c) { return c != OwnerCard && c.name.Contains("Jewel Knight"); }) >= 3 && HandSize() > 0)
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
            SelectInHand(1, true,
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
