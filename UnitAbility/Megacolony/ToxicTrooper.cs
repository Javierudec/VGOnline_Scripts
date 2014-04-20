using UnityEngine;
using System.Collections;

/*
 * AUTO 【V/R】: When this unit attacks, all of your 
 * opponent's units cannot intercept until end of that battle.
 */

public class ToxicTrooper : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			BlockIntercept();
			ConfirmAttack();
		}
	}
}
