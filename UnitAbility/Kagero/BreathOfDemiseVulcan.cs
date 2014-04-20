using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (1)] When this unit is placed on (VC) or (RC), if 
 * you have a «Bermuda Triangle» vanguard, you may pay the cost. If 
 * you do, put the top card of your deck into your damage zone, and at 
 * the beginning of your end phase, choose a card from your damage 
 * zone, return it to your deck, and shuffle your deck.
 */

public class BreathOfDemiseVulcan : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB (1) && VanguardIs("Kagero"))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
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
				SelectInDamage(1, true, 
				delegate {
					FromDamageToDeck(_SID_Card);	
					Game.field.RemoveFromHelpZone(OwnerCard);
					ShuffleDeck();
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectInDamage_Pointer();
	}
}
