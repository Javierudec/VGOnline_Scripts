using UnityEngine;
using System.Collections;

/*
 * [ACT](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (3)] If you have four or more rear-guards with 
 * "Battle Sister" in its card name, draw two cards.
 *
 * [CONT](VC):During your turn, if you have four or more rear-guards 
 * with "Battle Sister" in its card name, this unit gets [Power]+4000.
 */

public class BattleSisterFromage : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(IsPlayerTurn() && NumUnits(delegate(Card c) { return c.name.Contains("Battle Sister"); }) >= 4)
		{
			power += 4000;	
		}
		SetPower(power);
	}
	
	public override int Act ()
	{
		if(VC () && LimitBreak(4) && CB(1))
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(3,
			delegate {
				if(NumUnits(delegate(Card c) { return c.name.Contains("Battle Sister"); }) >= 4)
				{
					DrawCard(2);	
				}
			});
		});
		
		DrawCardUpdate(delegate {
			EndEffect();
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}

