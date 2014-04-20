using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):When this unit attacks, if the number of rear-guards you have with 
 * "Jewel Knight" in its card name is four or more, this unit gets 
 * [Power]+2000/[Critical]+1 until end of that battle.
 * 
 * [ACT](VC):[Counter Blast (2)-card with "Jewel Knight" in its card name] 
 * Search your deck for up to one card with "Jewel Knight" in its card name, 
 * call it to (RC), and shuffle your deck.
 */

public class LeadingJewelKnightSalome : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC() && LimitBreak(4) && NumUnits(delegate(Card c) { return c.name.Contains("Jewel Knight"); }) >= 4)
			{
				IncreasePowerByBattle(OwnerCard, 2000);
				IncreaseCriticalByBattle(OwnerCard, 1);
			}
		}
	}
	
	public override int Act ()
	{
		if(VC() && CB(2, delegate(Card c) { return c.name.Contains("Jewel Knight"); }) && GetDeck().Size() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SetBool(1);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.name.Contains("Jewel Knight");	
				});
			},
			delegate(Card c) {
				return c.name.Contains("Jewel Knight");
			});		
		});
		
		if(GetBool(1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				EndEffect();
				ShuffleDeck();
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
