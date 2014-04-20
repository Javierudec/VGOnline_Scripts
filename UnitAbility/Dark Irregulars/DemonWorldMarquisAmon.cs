using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):During your turn, this unit gets [Power]+1000 for each «Dark 
 * Irregulars» in your soul.
 * 
 * [ACT](VC):[Counter Blast (1) & Choose one of your «Dark Irregulars» rear-
 * guards, and put it into your soul] Your opponent chooses one of his or her 
 * rear-guards, and retires it.
 */

public class DemonWorldMarquisAmon : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC() && IsPlayerTurn())
		{
			power += NumUnitsInSoul(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) * 1000;	
		}
		SetPower(power);
	}	
	
	public override int Act ()
	{
		if(VC() && CB(1) && NumUnits(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) > 0 &&
			NumEnemyUnits(delegate(Card c) { return true; }) > 0)
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
		DelayUpdate (delegate {
			CounterBlast(1,
			delegate {
				SelectUnit("Choose one of your \"Dark Irregulars\" rear-guards.", 1, false,
				delegate {
					MoveToSoul(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Dark Irregulars");	
				},
				delegate {
					OpponentRetireUnit();
				});
			});
		});
	}
	
	public override void EndEvent ()
	{
		EndEffect();
	}
}

