using UnityEngine;
using System.Collections;

/*
 * [CONT](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):During your turn, this unit gets [Power]+2000 for each rear-guard 
 * you have with "Liberator" in its card name.
 * 
 * [ACT](VC):[Counter Blast (2)-card with "Liberator" in its card name] Look at 
 * the top card of your deck, search for up to one «Gold Paladin», call it to an 
 * open (RC), and put the rest on the bottom of your deck.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)
 */

public class LiberatorOfTheRoundTableAlfred : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC() && LimitBreak(4) && IsPlayerTurn())
		{
			power += NumUnits(delegate(Card c) { return c.name.Contains("Liberator"); }) * 2000;	
		}
		SetPower(power);
	}
	
	public override int Act ()
	{
		if(VC() && CB(2, delegate(Card c) { return c.name.Contains("Liberator"); }) && GetDeck().Size() > 0 && OpenRC())
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
	
	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SetBool(1);
				GetDeck().ViewDeck(1, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, 1, delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Gold Paladin");	
				});
			},
			delegate(Card c) {
				return c.name.Contains("Liberator");
			});
		});
		
		if(GetBool(1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				OnlyOpenRC(true);
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				EndEffect();	
			}
		}
		
		CallFromDeckUpdate(delegate {
			OnlyOpenRC(false);
			EndEffect ();	
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
