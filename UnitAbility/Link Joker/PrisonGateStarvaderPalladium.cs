using UnityEngine;
using System.Collections;

public class PrisonGateStarvaderPalladium : UnitObject {
	Card cardToLock = null;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EnemyUnlockCard)
		{
			if(GetEnemyPhase() == EnemyPhase.ENDTURN
			   && RC ()
			   && CB(1)
			   && VanguardIs("Link Joker"))
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				LockEnemyUnit(cardToLock);
				EndEffect();
			});
		});
	}
}
