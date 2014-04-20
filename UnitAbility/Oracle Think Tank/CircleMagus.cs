using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is placed on (VC) or (RC), if you have an «Oracle 
 * Think Tank» vanguard, look at the top card of your deck, and put that card 
 * on top of your deck.
 */

public class CircleMagus : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(VanguardIs("Oracle Think Tank") && GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				HideTopCard();
				EndEffect();
			}
			else
			{
				RevealTopCard(false);
				Delay(1);
				SetBool(1);
			}
		});
	}
}
