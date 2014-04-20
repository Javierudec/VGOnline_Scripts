using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, 
 * you may call this unit to (RC))
 * [AUTO](RC):[Counter Blast (1) & Put this unit into your soul]
 * During your end phase, when another of your «Great Nature» rear-guards
 * is put into your drop zone, you may pay the cost. If you do, put 
 * that card into your hand.
 */

public class GardeningMole : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			Forerunner("Great Nature");	
		}
		else if(cs == CardState.UnitSendToDropZoneFromRC)
		{
			if(RC () && CB(1) && ownerEffect.BelongsToClan("Great Nature") && CurrentPhaseIs(GamePhase.ENDTURN))
			{
				SetBool(1);
				DisplayConfirmationWindow();	
				_AuxCard1 = ownerEffect;
			}
		}
	}
	
	public override void Active ()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			ShowAndDelay();
		}
		else
		{
			Forerunner_Active();
		}
	}
	
	public override void Update ()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				FromDropToHand(_AuxCard1);
				_AuxCard1 = null;
				EndEffect();
			});
		});
	}
	
	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
