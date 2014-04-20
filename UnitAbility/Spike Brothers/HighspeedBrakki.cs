using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Soul Blast (1)] When this unit attacks, you may pay the 
 * cost. If you do, this unit gets [Power]+5000 until end of that battle, and 
 * at the beginning of the close step of that battle, return this unit to your 
 * deck, and shuffle your deck.
 */

public class HighspeedBrakki : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC () && CanSoulBlast(1))
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetBool(1))
			{
				UnsetBool(1);
				FromFieldToDeck(OwnerCard);
				ShuffleDeck();
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
			SoulBlast(1);
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 5000);
			SetBool(1);
			EndEffect();
		});
	}
}
