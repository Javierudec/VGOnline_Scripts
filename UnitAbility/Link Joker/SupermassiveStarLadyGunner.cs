using UnityEngine;
using System.Collections;

public class SupermassiveStarLadyGunner : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.IsBoosted)
		{
			Card tmp = OwnerCard.IsBoostedBy;
			if(tmp.BelongsToClan("Link Joker"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}
}
