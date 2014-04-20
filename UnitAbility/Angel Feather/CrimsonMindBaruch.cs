using UnityEngine;
using System.Collections;

/*
 * [ACT](Damage Zone):[Turn this card from face up to face down]
 * Choose your «Angel Feather» vanguard, and that unit gets [Power]+3000 until end of turn.
 */

public class CrimsonMindBaruch : UnitObject {
	public override int EffectOnDamage ()
	{
		if(OwnerCard.IsFaceup())
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
		DelayUpdate(delegate {
			Flipdown(OwnerCard);
			IncreasePowerByTurn(GetVanguard(), 3000);
			EndEffect();
		});
	}
}
