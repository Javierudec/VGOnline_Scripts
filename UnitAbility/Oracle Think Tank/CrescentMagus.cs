using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit boosts a «Oracle Think Tank», if you have an 
 * «Oracle Think Tank» vanguard, declare the card name of an «Oracle Think 
 * Tank», and reveal the top card of your deck. If the revealed card is the card 
 * that you declared, the boosted unit gets [Power]+3000 until end of that 
 * battle.
 */

public class CrescentMagus : UnitObject {
	string name;
	Card card;
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC() && tmp.BelongsToClan("Oracle Think Tank") && VanguardIs("Oracle Think Tank") && GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void SelectionCardNameOnClose (string nameSelected)
	{
		name = nameSelected;
		card = RevealTopCard();
		Delay(1);
		SetBool(1);
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				HideTopCard();
				if(name == card.name)
				{
					IncreasePowerByBattle(OwnerCard.boostedUnit, 3000);	
				}
				EndEffect();
			}
			else
			{
				OpenSelectionCardNameList(OwnerCard, "Declare the card name of an \"Oracle Think Tank\"", delegate(CardInformation c) {
					return c.BelongsToClan("Oracle Think Tank");	
				});
			}
		});
	}
}
