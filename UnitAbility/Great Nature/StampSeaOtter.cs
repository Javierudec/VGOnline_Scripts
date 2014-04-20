using UnityEngine;
using System.Collections;

/*
 * [CONT](RC):If you have a «Great Nature» vanguard, this unit cannot be 
 * retired by effects from cards.
 */

public class StampSeaOtter : UnitObject {
	bool lastBool = true;

	public override void Cont ()
	{
		OwnerCard.bCanBeRetireByEffects = !(RC () && VanguardIs("Great Nature"));

		if(lastBool != OwnerCard.bCanBeRetireByEffects)
		{
			lastBool = OwnerCard.bCanBeRetireByEffects;

			int n = 0;
			if(lastBool == true) n = 1;
			else n = 0;

			Game.SendPacket (GameAction.CAN_BE_RETIRED, OwnerCard.pos, n);
		}
	}
}
