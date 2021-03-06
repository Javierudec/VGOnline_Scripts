﻿using UnityEngine;
using System.Collections;

public class WhiteRoseMusketeerAlberto : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard()
			   && VanguardIs("Neo Nectar")
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
			Flipup(1, delegate {
				EndEffect();
			});
		});
	}
}
