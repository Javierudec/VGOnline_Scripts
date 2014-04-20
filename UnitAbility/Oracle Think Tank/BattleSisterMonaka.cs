using UnityEngine;
using System.Collections;

/*
 * [ACT] (VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (1) & Choose a card named "Battle Sister, Monaka" 
 * from your hand, and discard it] Look at five cards from the top of your deck, 
 * search for two cards from among them, put them into your hand, and put the 
 * rest on the bottom of your deck in any order.
 * 
 * [ACT](VC):[Counter Blast (2)-cards with "Battle Sister" in its card name] This 
 * unit gets [Power]+5000 until end of turn.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class BattleSisterMonaka : UnitObject {
	public override int Act ()
	{
		int numActive = 0;
		
		if(VC () && LimitBreak(4) && CB (1) && HandSize(delegate(Card c) { return c.cardID == CardIdentifier.BATTLE_SISTER__MONAKA; }) > 0 && GetDeck().Size() >= 5)
		{
			numActive++;
		}
		
		if(VC () && CB (2, delegate(Card c) { return c.name.Contains("Battle Sister"); }))
		{
			numActive++;	
		}
		
		return numActive;
	}
	
	public override void Active (int idAbility)
	{
		StartEffect();
		ShowAndDelay();
		SetBool(idAbility);
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			bool bActiveSecondAbility = false;
			if(GetBool(1))
			{
				if(VC () && LimitBreak(4) && CB (1) && HandSize(delegate(Card c) { return c.cardID == CardIdentifier.BATTLE_SISTER__MONAKA; }) > 0 && GetDeck().Size() >= 5)
				{
					CounterBlast(1,
					delegate {
						SelectInHand(1, false, 
						delegate {
							DiscardSelectedCard();
						},
						delegate {
							return _SIH_Card.cardID == CardIdentifier.BATTLE_SISTER__MONAKA;
						},
						delegate {
							SetBool(3);
							GetDeck().DisableCloseButton();
							GetDeck().ViewDeck(2, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, 5, delegate(Game2DCard c) {
								return true;
							});
						}, "Choose a card named \"Battle Sister, Monaka\" from your hand.");
					});
				}
				else
				{
					bActiveSecondAbility = true;
				}
			}
			else
			{
				bActiveSecondAbility = true;
			}
			
			if(bActiveSecondAbility)
			{
				CounterBlast(2,
				delegate {
					IncreasePowerByTurn(OwnerCard, 5000);
					EndEffect();
				},
				delegate(Card c) {
					return c.name.Contains("Battle Sister");	
				});
			}
		});
		
		if(GetBool(3) && !GetDeck().IsOpen())
		{
			UnsetBool(3);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			for(int i = 0; i < _AuxIdVector.Count; i++)
			{
				FromDeckToHand(_AuxIdVector[i]);	
			}
			EndEffect();
		}
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectInHand_Pointer();
	}
}
