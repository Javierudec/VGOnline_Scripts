using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Soul Blast (2)] When this unit is placed on (RC), if you have an 
 * «Oracle Think Tank» vanguard, you may pay the cost. If you do, choose up 
 * to two cards from your damage zone, and turn them face up.
 */

public class BattleSisterLemonade : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(VanguardIs("Oracle Think Tank") && CanSoulBlast(2) && GetFacedownDamage() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			SoulBlast(2);	
		});
		
		SoulBlastUpdate(delegate {
			int m = min (GetFacedownDamage(), 2);
			Flipup(m,
			delegate {
				EndEffect();	
			});
		});
	}
	
	public override void Pointer ()
	{
		Flipup_Pointer(true);
	}
}
