using UnityEngine;
using System.Collections;

public class InnocentBladeHeartless : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(VC ()
			   && GetDefensor().IsVanguard()
			   && CB(2)
			   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC ()
			   && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
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
		});
	}
}
