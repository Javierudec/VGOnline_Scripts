using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan 
 * rides this unit, you may call this unit to (RC))
 * [CONT](VC/RC): Restraint (This unit cannot attack.)
 * [CONT](RC):This unit cannot boost a rear-guard.
 */
 
public class DeitySealingKidSohKoh : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			Forerunner("Narukami");	
		}
	}
	
	public override void Active ()
	{
		Forerunner_Active();
	}
	
	public override void Update ()
	{
		Forerunner_Update();
	}
}
