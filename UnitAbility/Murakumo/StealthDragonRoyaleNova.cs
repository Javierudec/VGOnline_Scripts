using UnityEngine;
using System.Collections;

/*
 * [CONT](VC/RC): If you do not have a unit named 
 * "Covert Demonic Dragon, Magatsu Storm" or "Stealth Dragon, 
 * Magatsu Gale" on your (VC), this units gets [Power]-5000. 
 * 
 * [AUTO](VC/RC): When this unit attacks, this unit gets 
 * [Power]+2000 until end of battle.
 */
 
public class StealthDragonRoyaleNova : UnitObject {
	public override void Cont ()
	{
		if(!IsInSoul(CardIdentifier.COVERT_DEMONIC_DRAGON__MAGATSU_STORM) 
		   && !IsInSoul(CardIdentifier.STEALTH_DRAGON__MAGATSU_GALE))
		{
			AddContPower(-5000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			IncreasePowerByTurn(OwnerCard, 2000);
		}
	}
}
