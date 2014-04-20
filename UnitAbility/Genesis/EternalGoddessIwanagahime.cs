using UnityEngine;
using System.Collections;

/*
 * [ACT](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Soul Blast (6)] Retire all of your opponent's rear-guards in the 
 * front row.
 * 
 * [ACT](VC):[Soul Blast (3)] This unit gets [Power]+5000 until end of turn
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class EternalGoddessIwanagahime : UnitObject {
	public override int Act ()
	{
		int n = 0;
		
		if(VC() && LimitBreak(4) && CanSoulBlast(6))
		{
			n++;	
		}
		
		if(VC() && CanSoulBlast(3))
		{
			n++;	
		}
		
		return n;
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
			if(GetBool(1))
			{
				UnsetBool(1);
				if(VC() && LimitBreak(4) && CanSoulBlast(6))
				{
					SoulBlast(6);	
					SetBool(3);
				}
				else
				{
					SoulBlast(3);
					SetBool(4);
				}
			}
			else
			{
				UnsetBool(2);
				SoulBlast(3);
				SetBool(4);
			}
		});
		
		SoulBlastUpdate(delegate {
			if(GetBool(3))
			{
				UnsetBool(3);
				ForEachEnemyUnitOnField(delegate(Card c) {
					if(IsFrontRow(c))
					{
						RetireEnemyUnit(c);	
					}
				});
				EndEffect();
			}
			
			if(GetBool(4))
			{
				UnsetBool(4);	
				IncreasePowerByTurn(OwnerCard, 5000);
				EndEffect();
			}
		});
	}
}
