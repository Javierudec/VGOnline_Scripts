using UnityEngine;
using System.Collections;

/*
 * [CONT](VC/RC):If you do not have another «Nova Grappler» vanguard or 
 * rear-guard, this unit gets [Power] -2000.
 * 
 * [AUTO](VC):When this unit's drive check reveals a grade 3 «Nova 
 * Grappler», choose one of your rear-guards, and [Stand] it.
 */

public class AsuraKaiser : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(NumUnits(delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Nova Grappler"); }, true) <= 0)
		{
			power -= 2000;	
		}
		SetPower(power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC () && ownerEffect.grade == 3 && ownerEffect.BelongsToClan("Nova Grappler"))
			{
				if(NumUnits(delegate(Card c) { return !c.IsStand(); }) > 0)
				{
					StartEffect();
					ShowAndDelay();
				}
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your rear-guards.", 1, true,
			delegate {
				StandUnit(Unit);
			},
			delegate {
				return !Unit.IsStand();
			},
			delegate {
				
			});
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
	}
}
