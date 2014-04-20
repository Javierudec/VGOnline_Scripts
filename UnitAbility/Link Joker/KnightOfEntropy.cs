using UnityEngine;
using System.Collections;

public class KnightOfEntropy : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && LimitBreak(4)
			   && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 5000);
			}
		}
		else if(cs == CardState.Ride)
		{
			if(CB(2)
			   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SelectUnit("Choose one of your opponent's rear-guards.", 1, true,
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
