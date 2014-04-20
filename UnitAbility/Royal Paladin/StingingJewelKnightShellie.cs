using UnityEngine;
using System.Collections;

public class StingingJewelKnightShellie : UnitObject {
    public override void Auto(CardState cs, Card effectOwner)
    {
        if (cs == CardState.Attacking)
        {
            if (RC() && NumUnits(delegate(Card c) { return c != OwnerCard && c.name.Contains("Jewel Knight"); }) >= 3)
            {
                IncreasePowerByBattle(OwnerCard, 3000);
            }
        }
    }
}
