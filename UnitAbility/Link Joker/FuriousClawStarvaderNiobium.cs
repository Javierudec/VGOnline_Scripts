using UnityEngine;
using System.Collections;

public class FuriousClawStarvaderNiobium : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EnemyIsLocked)
		{
			if(RC ()
			   && VanguardIs("Link Joker"))
			{
				IncreasePowerByTurn(OwnerCard, 2000);
			}
		}
	}
}
