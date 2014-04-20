using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC):[Choose a card from your damage zone, and put it into the 
 * bottom of your deck] At the beginning of your main phase, you may pay 
 * the cost. If you do, put the top card of your deck into your damage 
 * zone. If the card put into the damage zone is an «Angel Feather», 
 * this unit gets [Power]+3000 until end of turn, and if not, 
 * [Rest] this unit.
 */

public class ReverseAuraPhoenix : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.BeginMain)
		{
			if(VC() && Game.field.GetDamage() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active ()
	{
		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				Card tmp = GetDeck ().TopCard();
				FromDeckToDamage(tmp, true);
				if(tmp.BelongsToClan("Angel Feather"))
				{
					IncreasePowerByTurn(OwnerCard, 3000);
				}
				else
				{
					RestUnit(OwnerCard);
				}
			}
			else
			{
				SelectInDamage(1, true,
				delegate {
					FromDamageToDeck(_SID_Card, true);
					SetBool(1);
					Delay (0.5f);
				});
			}
		});
	}
}
