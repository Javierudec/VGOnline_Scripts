using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, you may 
 * call this unit to (RC))
 * 
 * [AUTO](RC):[Put this unit into your soul] When an attack hits a vanguard 
 * during the battle that this unit boosted a unit with "Liberator" in its card name, 
 * you may pay the cost. If you do, choose one card named "Blaster Blade 
 * Liberator" from your soul, and call it to an open (RC).
 */

public class WingalLiberator : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.RideAboveIt)
        {
            if (VanguardIs("Gold Paladin"))
            {
                SetBool(1);
                Forerunner("Gold Paladin");
            }
        }
        else if (cs == CardState.AttackHits_NotMe)
        {
            Card tmp = OwnerCard.boostedUnit;

            if (tmp != null 
                && GetAttacker() == tmp 
                && GetDefensor().IsVanguard() 
                && tmp.name.Contains("Liberator") 
                && RC() 
                && IsInSoul(CardIdentifier.BLASTER_BLADE_LIBERATOR)
                && OpenRC())
            {
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
            Forerunner_Active();
        }
        else
        {
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
            SetBool(2);
            Game.field.ViewSoul(1,
            delegate(Card c)
            {
                return c.cardID == CardIdentifier.BLASTER_BLADE_LIBERATOR;
            });
        });

        ResolveSoulOpening(2,
        delegate
        {
            CallFromSoul(Game.field.GetSoulByID(_AuxIdVector[0]));
        },
        delegate
        {
            EndEffect();
        });

        CallFromDeckUpdate(
        delegate
        {
            EndEffect();
        });
    }
}
