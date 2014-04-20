using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Soul Blast (1) - Cards with "Liberator" in its card name] When this 
 * unit is placed on (RC) from your deck, if you have a vanguard with 
 * "Liberator" in its card name, you may pay the cost. If you do, draw a card.
 */

public class FastChaseLiberatorJosephus : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.CallFromDeck)
        {
            if (CanSoulBlast(1, delegate(Card c) { return c.name.Contains("Liberator"); }) && GetVanguard().name.Contains("Liberator") && GetDeck().Size() > 0)
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
            SoulBlast(1,
            delegate(Card c)
            {
                return c.name.Contains("Liberator");
            });
        });

        SoulBlastUpdate(
        delegate
        {
            DrawCard(1);
        });

        DrawCardUpdate(
        delegate
        {
            EndEffect();
        });
    }
}
