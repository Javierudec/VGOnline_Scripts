using UnityEngine;
using System.Collections;

public class StarvaderFreezeRayDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EnemyIsLocked) 
		{
			if(VC()
			   && LimitBreak(4))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
		else if(cs == CardState.CardPutInDamage)
		{
			if(VC()
			   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
			delegate {
				LockEnemyUnit(EnemyUnit);
			},
			delegate {
				return true;
			},
			delegate {

			});
		});
	}
}
