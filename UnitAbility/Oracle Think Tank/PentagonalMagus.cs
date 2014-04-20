using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):When this unit attacks a vanguard, declare the card name of an 
 * «Oracle Think Tank», and reveal the top card of your deck. If the revealed 
 * card is the card that you declared, this unit gets [Power]+5000/[Critical]+1 
 * until end of that battle.
 * 
 * [ACT](VC):[Counter Blast (2)-cards with "Magus" in its card name] This unit 
 * gets [Power]+5000 until end of turn.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class PentagonalMagus : UnitObject {
	string name;
	Card card;
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && GetDefensor().IsVanguard() && LimitBreak(4))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override int Act ()
	{
		if(VC() && CB (2, delegate(Card c) {
			return c.name.Contains("Magus");
		}))
		{
			return 1;
		}
		
		return 0;
	}
	
	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
		SetBool(2);
	}
	
	public override void SelectionCardNameOnClose (string nameSelected)
	{
		name = nameSelected;
		card = RevealTopCard();
		SetBool(1);
		Delay(1);
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
					IncreasePowerByBattle(OwnerCard, 5000);
					IncreaseCriticalByBattle(OwnerCard, 1);
				}
				EndEffect();
			}
			else if(GetBool(2))
			{
				UnsetBool(2);
				CounterBlast(2,
				delegate {
					IncreasePowerByTurn(OwnerCard, 5000);
					EndEffect();
				},
				delegate(Card c) {
					return c.name.Contains("Magus");
				});
			}
			else
			{
				OpenSelectionCardNameList(OwnerCard, "Declare the name of an \"Oracle Think Tank\".", delegate(CardInformation c) {
					return c.BelongsToClan("Oracle Think Tank");
				});
			}
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
