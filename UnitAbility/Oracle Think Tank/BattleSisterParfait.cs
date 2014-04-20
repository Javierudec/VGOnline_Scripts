using UnityEngine;
using System.Collections;

/*
 * [CONT](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):During your turn, if the number of cards in your hand is four or 
 * greater, this unit gets [Power]+3000 and "[AUTO](VC):When this unit's 
 * attack hits a vanguard, draw a card.".
 * 
 * [ACT](VC):[Counter Blast (2)-cards with "Battle Sister" in its card name] If 
 * the number of cards in your hand is three or less, draw a card.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class BattleSisterParfait : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC () && LimitBreak(4) && IsPlayerTurn() && HandSize() >= 4)
		{
			power += 3000;
			SetBool(1);
		}
		else
		{
			UnsetBool(1);	
		}
		SetPower(power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(VC () && GetDefensor().IsVanguard())
			{
				DrawCardWithoutDelay();
			}
		}
	}
	
	public override int Act ()
	{
		if(VC () && CB(2, delegate(Card c) { return c.name.Contains("Battle Sister"); }))
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
				if(HandSize() >= 3)
				{
					DrawCardWithoutDelay();
				}
				EndEffect();
			},
			delegate(Card c){
				return c.name.Contains("Battle Sister");	
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
