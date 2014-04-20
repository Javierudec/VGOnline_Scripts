using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC): When this unit's attack hits a vanguard, if you have a «Tachikaze» 
 * vanguard, choose a card from your damage zone, and turn it face up.
 */

public class LauncherMammoth : UnitObject {
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard()
			   && VanguardIs("Tachikaze")
			   && NumUnitsDamage(delegate(Card c) { return !c.IsFaceup(); }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			Flipup(1,
			delegate {
				EndEffect();
			});
		});
	}
}
