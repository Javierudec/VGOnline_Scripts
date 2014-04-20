using UnityEngine;
using System.Collections;

public class DemonicClawStarvaderLanthanum : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EnemyIsLocked)
		{
			if(VanguardIs("Link Joker"))
			{
				IncreasePowerByTurn(OwnerCard, 2000);
			}
		}
	}
}
