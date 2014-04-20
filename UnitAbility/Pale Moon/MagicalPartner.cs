using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):[Soul Blast (1)] When this unit boosts a unit 
 * named "Nightmare Summoner, Raqiel", you may pay the 
 * cost. If you do, the boosted unit gets [Power]+5000 until 
 * end of that battle. 
 */

public class MagicalPartner : UnitObject {
	CardIdentifier _cardID = CardIdentifier.NIGHTMARE_SUMMONER__RAQIEL;
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack ();	
		}
		else if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC () && CanSoulBlast(1) && tmp != null && tmp.cardID == _cardID)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard.boostedUnit, 5000);
			EndEffect();
		});
	}
}
