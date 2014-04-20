using UnityEngine;
using System.Collections;

public class MythGuardAchemar : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DropFromSoul_NotMe)
		{
			if(RC ()
			   && ownerEffect.cardID == CardIdentifier.MYTH_GUARD__ACHERNAR
			   && VanguardIs("Genesis"))
			{
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
}
