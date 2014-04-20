using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):When an «Angel Feather» rides this unit, choose a card from 
 * your damage zone, put it into your hand, and put the top card of your 
 * deck into your damage zone, and choose your vanguard, and that unit gets 
 * [Power]+10000 until end of turn.
 * 
 * [AUTO](VC):When this unit attacks a vanguard, this unit gets [Power]+2000 
 * until end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class ProphecyCelestialRamiel : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Angel Feather")
			   && NumUnitsDamage() > 0
			   && GetDeck ().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC () 
			   && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				FromDeckToDamage(GetDeck ().TopCard());
				IncreasePowerByTurn(GetVanguard(), 10000);
				EndEffect();
			}
			else
			{
				SelectInDamage(1, false,
				delegate {
					FromDamageToHand(_SID_Card);
					Delay (0.5f);
					SetBool(1);
				});
			}
		});
	}
}
